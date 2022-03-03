using System.Data.SqlClient;

namespace ShoppingDL
{
    public class AdminRepository : IRepository_a
    {
        private readonly string _connectionStrings;
        public AdminRepository(string p_connectionStrings)
        {
            _connectionStrings = p_connectionStrings;
        }


        public Admin AddAdmin(Admin b_admin)
         {
            string _sqlQuery = @"INSERT INTO Admin
                VALUES(@adminID, @adminName, @adminEmail, @adminUsername, @adminPassword, @createdAt)";

            b_admin.AdminID = Guid.NewGuid();
            b_admin.CreatedAt = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
        using (SqlConnection con = new SqlConnection(_connectionStrings))
        {
        con.Open();

        SqlCommand command = new SqlCommand(_sqlQuery, con);
        command.Parameters.AddWithValue("@adminID", b_admin.AdminID);
        command.Parameters.AddWithValue("@adminName", b_admin.AdminName);
        command.Parameters.AddWithValue("@adminEmail", b_admin.AdminEmail);
        command.Parameters.AddWithValue("@adminUsername", b_admin.AdminUsername);
        command.Parameters.AddWithValue("@adminPassword", b_admin.AdminPassword);
        command.Parameters.AddWithValue("@createdAt", b_admin.CreatedAt);
        
        command.ExecuteNonQuery();
        }

        return b_admin;
        }

        public List<Admin> GetAllAdmin()
        {
            string _sqlQuery = @"SELECT * FROM Admin";
        List<Admin> listOfAdmin = new List<Admin>();

        using (SqlConnection con = new SqlConnection(_connectionStrings))
        {
        con.Open();

        SqlCommand command = new SqlCommand(_sqlQuery, con);

        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
          listOfAdmin.Add(new Admin()
          {
            AdminID = reader.GetGuid(0),
            AdminName = reader.GetString(1),
            AdminEmail = reader.GetString(2),
            AdminUsername = reader.GetString(3),
            AdminPassword = reader.GetString(4),
            CreatedAt = reader.GetDateTime(5)
          });
        }
      }

      return listOfAdmin;
        }
    }

}