using System.Data.SqlClient;
using ShoppingModel;

namespace ShoppingDL
{
    public class ProductRepository : IRepository_p
    {

        private readonly string _connectionStrings;
        public ProductRepository(string p_connectionStrings)
        {
         _connectionStrings = p_connectionStrings;
        }

        
      
        public Product AddProduct(Product b_product)
        {
            string sqlQuery = @"insert into Product 
                              values(@productID, @productName, @productDescription, @productPrice, @createdAt)";
              
              b_product.createdAt = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@productID", b_product.ProductID);
                command.Parameters.AddWithValue("@productName", b_product.ProductName);
                command.Parameters.AddWithValue("@productDescription", b_product.ProductDescription);
                command.Parameters.AddWithValue("@productPrice", b_product.ProductPrice);
                command.Parameters.AddWithValue("@createdAt", b_product.createdAt);

              
                command.ExecuteNonQuery();
            }
            return b_product;
        }


        public List<Product> GetAllProduct()
        {
            List<Product> listOfProduct = new List<Product>();

            string sqlQuery = @"SELECT * FROM Product";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
              
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfProduct.Add(new Product(){
                       
                        ProductID = reader.GetGuid(0), 
                        ProductName = reader.GetString(1), 
                        ProductDescription = reader.GetString(2),
                        ProductPrice = reader.GetDecimal(3),
                        createdAt = reader.GetDateTime(4),
                        
                    });
                }
            }
        return listOfProduct;
       }



        public List<Product> GetAllProductsFromStore(Guid b_storeID)
        {
            List<Product> _listOfProducts = new List<Product>();
      string _sqlQuery = @"SELECT p.productID, p.productName,p.productDescription , p.productPrice, p.createdAt FROM Product p, StoreFront sf, Inventory i
                          WHERE p.productID = i.productID 
                            AND sf.storeID = i.storeID
                            AND sf.storeID = @storeID";

      using (SqlConnection con = new SqlConnection(_connectionStrings))
      {
        con.Open();

        SqlCommand command = new SqlCommand(_sqlQuery, con);
        command.Parameters.AddWithValue("@storeID", b_storeID);

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          _listOfProducts.Add(new Product()
          {
            ProductID = reader.GetGuid(0), 
                        ProductName = reader.GetString(1), 
                        ProductDescription = reader.GetString(2),
                        ProductPrice = reader.GetDecimal(3),
                        createdAt = reader.GetDateTime(4),
          });
        }
      }

      return _listOfProducts;
        }

        public List<StoreFront> GetAllStoreFrontsByProductID(Guid b_productID)
    {
        List<StoreFront> StoreFront = new List<StoreFront>();

      string _sqlQuery = @"SELECT sf.storeID, sf.storeName, sf.storeLocation, sf.createdAt FROM StoreFront sf, Inventory i, Products p
                          WHERE sf.storeID = i.storeID 
                            AND i.productID = p.productID
                            AND p.productID = @productID";

      using (SqlConnection con = new SqlConnection(_connectionStrings))
      {
        con.Open();

        SqlCommand command = new SqlCommand(_sqlQuery, con);
        command.Parameters.AddWithValue("@productID", b_productID);

        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
          StoreFront.Add(new StoreFront()
          {
            StoreID = reader.GetGuid(0),
            StoreName = reader.GetString(1),
            StoreLocation = reader.GetString(2)
          });
        }
      }

       return StoreFront;
        }


        public Product GetProductDetail(Guid b_productID)
        {
            return GetAllProduct().Where(p => p.ProductID == b_productID).First();
        }

        public List<Product> SearchProduct(string p_name)
        {
            throw new NotImplementedException();
        }

        public Product UpdateProduct(Product b_product)
        {
        string _sqlQuery = @"UPDATE Product
                          SET productName = @productName, 
                          productDescription = @productDescription,
                          productPrice = @productPrice, 
                          WHERE productID = @productID";

        using (SqlConnection con = new SqlConnection(_connectionStrings))
        {
        con.Open();

        SqlCommand command = new SqlCommand(_sqlQuery, con);

        
        command.Parameters.AddWithValue("@productName", b_product.ProductName);
        command.Parameters.AddWithValue("@productDescription", b_product.ProductDescription);
        command.Parameters.AddWithValue("@productPrice", b_product.ProductPrice);
        command.Parameters.AddWithValue("@productID", b_product.ProductID);

        command.ExecuteNonQuery();
      }

      return b_product;
        }
    }
}