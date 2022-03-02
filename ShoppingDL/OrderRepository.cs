using System.Data.SqlClient;

namespace ShoppingDL
{
    public class OrderRepository : IRepository_o
    {
         private readonly string _connectionStrings;
        public OrderRepository(string p_connectionStrings)
        {
            _connectionStrings = p_connectionStrings;
        }


    public async Task<Order> PlaceOrder(Order b_order)
    {
      string _sqlQuery = @"INSERT INTO Orders
                         
                         VALUES(@orderID, @customerID, @storeID, @totalPrice, @createdAt)";

      b_order.OrderID = Guid.NewGuid();
      b_order.createdAt = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
      b_order.TotalPrice = CalTotalPrice(b_order);

      using (SqlConnection conn = new SqlConnection(_connectionStrings))
      {
        await conn.OpenAsync();

        SqlCommand command = new SqlCommand(_sqlQuery, conn);

        command.Parameters.AddWithValue("@orderID", b_order.OrderID);
        command.Parameters.AddWithValue("@customerID", b_order.CustomerID);
        command.Parameters.AddWithValue("@storeID", b_order.StoreID);
        command.Parameters.AddWithValue("@totalPrice", b_order.TotalPrice);
        command.Parameters.AddWithValue("@createdAt", b_order.createdAt);
        

        await command.ExecuteNonQueryAsync();

        await AddLineItemsToOrder(b_order);
        await SubstractInventoryAfterPlacedOrder(b_order);
      }

      return b_order;
    }


      public async Task<List<Order>> GetAllOrders()
      {
      string _sqlQuery = @"SELECT *
                          FROM Orders;";
      List<Order> _listOfOrders = new List<Order>();

      using (SqlConnection conn = new SqlConnection(_connectionStrings))
      {
        await conn.OpenAsync();

        SqlCommand command = new SqlCommand(_sqlQuery, conn);

        SqlDataReader reader = await command.ExecuteReaderAsync();

        while (reader.Read())
        {
          _listOfOrders.Add(new Order()
          {
            OrderID = reader.GetGuid(0),
            CustomerID = reader.GetGuid(1),
            StoreID = reader.GetGuid(2),
            TotalPrice = reader.GetDecimal(3),
            createdAt = reader.GetDateTime(4),
            ShoppingCart = await GetLineItemsByOrderID(reader.GetGuid(0))
          });
        }
      }

      return _listOfOrders;
    }

    public async Task<List<LineItem>> AddLineItemsToOrder(Order b_order)
    {
      string _sqlQuery = @"INSERT INTO LineItems
                          (productID, orderID, productQuantity, priceAtCheckout)
                    VALUES(@productID, @orderID, @productQuantity, @priceAtCheckout);";

      using (SqlConnection conn = new SqlConnection(_connectionStrings))
      {
        await conn.OpenAsync();

        SqlCommand command = new SqlCommand(_sqlQuery, conn);

        foreach (var item in b_order.ShoppingCart)
        {
          command = new SqlCommand(_sqlQuery, conn);
        
          command.Parameters.AddWithValue("@productID", item.ProductID);
          command.Parameters.AddWithValue("@orderID", b_order.OrderID);
          command.Parameters.AddWithValue("@productQuantity", item.ProductQuantity);
          command.Parameters.AddWithValue("@priceAtCheckout", item.priceAtCheckout);
          

          await command.ExecuteNonQueryAsync();
        }
      }

      return b_order.ShoppingCart;
    }



    public async Task SubstractInventoryAfterPlacedOrder(Order b_order)
    {
      string _sqlQuery = @"UPDATE Inventory
                          SET productQuantity=productQuantity - @productQuantity
                          WHERE storeID = @storeID AND productID = @productID;";

      using (SqlConnection conn = new SqlConnection(_connectionStrings))
      {
        await conn.OpenAsync();

        SqlCommand command = new SqlCommand();

        foreach (var item in b_order.ShoppingCart)
        {
          command = new SqlCommand(_sqlQuery, conn);

          command.Parameters.AddWithValue("@productQuantity", item.ProductQuantity);
          command.Parameters.AddWithValue("@storeID", b_order.StoreID);
          command.Parameters.AddWithValue("@productID", item.ProductID);

          await command.ExecuteNonQueryAsync();
        }
      }
    }
        

    public async Task<List<LineItem>> GetLineItemsByOrderID(Guid b_orderID)
    {
      string _sqlQuery = @"SELECT productID, productQuantity, priceAtCheckout
                          FROM LineItems
                          WHERE orderID = @orderID;";
      List<LineItem> _ShopCart = new List<LineItem>();

      using (SqlConnection conn = new SqlConnection(_connectionStrings))
      {
        await conn.OpenAsync();

        SqlCommand command = new SqlCommand(_sqlQuery, conn);

        command.Parameters.AddWithValue("@orderID", b_orderID);

        SqlDataReader reader = await command.ExecuteReaderAsync();

        while (reader.Read())
        {
          _ShopCart.Add(new LineItem()
          {
            ProductID = reader.GetGuid(0),
            OrderID = reader.GetGuid(1),
            ProductQuantity = reader.GetInt32(2),
            priceAtCheckout = reader.GetDecimal(3)
          });
        }
      }

      return _ShopCart;
    }


      public async Task<Order> UpdateOrder(Order b_order)
      {
            string _sqlQuery = @"DELETE FROM LineItems
                          WHERE orderID=@orderID;";

            string _sqlQuery2 = @"UPDATE Orders
                          SET totalPrice=@totalPrice
                          WHERE orderID=@orderID;";

      using (SqlConnection conn = new SqlConnection(_connectionStrings))
      {
        await conn.OpenAsync();

        SqlCommand command = new SqlCommand(_sqlQuery, conn);

        command.Parameters.AddWithValue("@orderID", b_order.OrderID);

        await command.ExecuteNonQueryAsync();

        b_order.TotalPrice = CalTotalPrice(b_order);

        command = new SqlCommand(_sqlQuery2, conn);
        command.Parameters.AddWithValue("@orderID", b_order.OrderID);
        command.Parameters.AddWithValue("@totalPrice", b_order.TotalPrice);
        await command.ExecuteNonQueryAsync();

        
        await AddLineItemsToOrder(b_order);
      }

      return b_order;
      }


      protected decimal CalTotalPrice(Order b_order)
      {
      decimal _totalPrice = 0m;

      foreach (var item in b_order.ShoppingCart)
      {
        _totalPrice += item.ProductQuantity * item.priceAtCheckout ;
      }

      return _totalPrice;
    }

    }
}