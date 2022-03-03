using System.Data.SqlClient;

namespace ShoppingDL
{
    public class CustomerRepository : IRepository_c
    {
         private readonly string _connectionStrings;
        public CustomerRepository(string p_connectionStrings)
        {
            _connectionStrings = p_connectionStrings;
        }

        public NewCustomer AddCustomer(NewCustomer b_customer)
         {
            string _sqlQuery = @"INSERT INTO Customer
                VALUES(@customerID, @customerName, @customerAddress, @customerEmail, @customerUsername,  @customerPassword)";
                   b_customer.CustomerID = Guid.NewGuid();
                   b_customer.CreatedAt = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
        using (SqlConnection con = new SqlConnection(_connectionStrings))
        {
        con.Open();

        SqlCommand command = new SqlCommand(_sqlQuery, con);
        command.Parameters.AddWithValue("@customerID", b_customer.CustomerID);
        command.Parameters.AddWithValue("@customerName", b_customer.CustomerName);
        command.Parameters.AddWithValue("@customerAddress", b_customer.CustomerAddress);
        command.Parameters.AddWithValue("@customerEmail", b_customer.CustomerEmail);
        command.Parameters.AddWithValue("@customerUsername", b_customer.CustomerUsername);
        command.Parameters.AddWithValue("@customerPassword", b_customer.CustomerPassword);
       
        command.ExecuteNonQuery();
        }

      return b_customer;
        }


        public ReturningCustomer DeleteCustomer(ReturningCustomer b_customer)
        {
             string sqlQuery = @"delete from Customer
                                where customerID = @Id";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand com = new SqlCommand(sqlQuery, con);

                //Setting Parameters
                com.Parameters.AddWithValue("@Id", b_customer.CustomerID);

                com.ExecuteNonQuery();
            }
            
            return b_customer;
        }


        public List<ReturningCustomer> GetAllCustomerOld()
        {
            
        string _sqlQuery = @"SELECT * FROM Customer";
        List<ReturningCustomer> listOfCustomer = new List<ReturningCustomer>();

        using (SqlConnection con = new SqlConnection(_connectionStrings))
        {
        con.Open();

        SqlCommand command = new SqlCommand(_sqlQuery, con);

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          listOfCustomer.Add(new ReturningCustomer()
          {
            CustomerID = reader.GetGuid(0),
            CustomerName = reader.GetString(1),
            CustomerAddress = reader.GetString(2),
            CustomerEmail = reader.GetString(3),
            CustomerUsername = reader.GetString(4),
            CustomerPassword = reader.GetString(5)
            
          });
        }
      }

      return listOfCustomer;
        }

      public List<ReturningCustomer> GetAllCustomers()
      {
        string _sqlQuery = @"SELECT @customerUsername, @customerPassword FROM Customer";
        List<ReturningCustomer> listOfCustomer = new List<ReturningCustomer>();

        using (SqlConnection con = new SqlConnection(_connectionStrings))
        {
        con.Open();

        SqlCommand command = new SqlCommand(_sqlQuery, con);

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          listOfCustomer.Add(new ReturningCustomer()
          {
            CustomerUsername = reader.GetString(0),
            CustomerPassword = reader.GetString(1)
          });
        }
      }

      return listOfCustomer;
      }


        public ReturningCustomer UpdateCustomer(ReturningCustomer b_customer)
        {
            
            string _sqlQuery = @"UPDATE Customer SET customerName = @customerName, customerAddress = @customerAddress,  customerUsername = @customerUsername, customerEmail = @customerEmail, customerPassword = @customerPassword
                              WHERE customerID = @customerID";

        using (SqlConnection con = new SqlConnection(_connectionStrings))
        {
        con.Open();

        SqlCommand command = new SqlCommand(_sqlQuery, con);

        command.Parameters.AddWithValue("@customerName", b_customer.CustomerName);
        command.Parameters.AddWithValue("@customerAddress", b_customer.CustomerAddress);
        command.Parameters.AddWithValue("@customerEmail", b_customer.CustomerEmail);
        command.Parameters.AddWithValue("@customerUsername", b_customer.CustomerUsername);
        command.Parameters.AddWithValue("@customerPassword", b_customer.CustomerPassword);
        command.Parameters.AddWithValue("@customerID", b_customer.CustomerID);
        
       
        command.ExecuteNonQuery();
      }

      return b_customer;
      }


      
    }
}