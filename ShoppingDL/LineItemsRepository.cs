using System.Data.SqlClient;

namespace ShoppingDL
{
    public class LineItemsRepository : IRepository_cart
    {
        private readonly string _connectionStrings;
        public LineItemsRepository(string p_connectionStrings)
        {
            _connectionStrings = p_connectionStrings;
        }

      public async Task<LineItem> AddLineItem(LineItem b_item)
      {
      string _sqlQuery = @"INSERT INTO LineItems
                          (productID, orderID, productQuantity, priceAtCheckout)
                    VALUES(@productID, @orderID, @productQuantity, @priceAtCheckout);";
     
       b_item.OrderID = Guid.NewGuid();
       b_item.ProductID = Guid.NewGuid();
       
      
      using (SqlConnection conn = new SqlConnection(_connectionStrings))
      {
        await conn.OpenAsync();

        SqlCommand command = new SqlCommand(_sqlQuery, conn);
        
          command.Parameters.AddWithValue("@productID", b_item.ProductID);
          command.Parameters.AddWithValue("@orderID", b_item.OrderID);
          command.Parameters.AddWithValue("@productQuantity", b_item.ProductQuantity);
          command.Parameters.AddWithValue("@priceAtCheckout", b_item.price);
          
          await command.ExecuteNonQueryAsync();
      
      }
      return b_item;
      
    }
}
}