using System.Data.SqlClient;

namespace ShoppingDL
{
    public class StoreRepository : IRepository_s
    {
         private readonly string _connectionStrings;
        public StoreRepository(string p_connectionStrings)
        {
            _connectionStrings = p_connectionStrings;
        }

       

     public async Task<StoreFront> AddNewStoreFront(StoreFront b_store)
        {
            string _sqlQuery = @"INSERT INTO StoreFront
                          (storeID, storeName, storeLocation)
                          VALUES(@storeID, @storeName, @storeLocation);";
            b_store.StoreID = Guid.NewGuid();
         using (SqlConnection conn = new SqlConnection(_connectionStrings))
         {
         await conn.OpenAsync();

        SqlCommand command = new SqlCommand(_sqlQuery, conn);

        command.Parameters.AddWithValue("@storeID", b_store.StoreID);
        command.Parameters.AddWithValue("@storeName", b_store.StoreName);
        command.Parameters.AddWithValue("@storeLocation", b_store.StoreLocation);
        

        await command.ExecuteNonQueryAsync();
        }

      return b_store;
    }


    public async Task<List<StoreFront>> GetAllStore()
    {
            string _sqlQuery = @"SELECT *
                          FROM StoreFront;";
           
        List<StoreFront> _listStores = new List<StoreFront>();

       using (SqlConnection conn = new SqlConnection(_connectionStrings))
      {
        await conn.OpenAsync();

        SqlCommand command = new SqlCommand(_sqlQuery, conn);

        SqlDataReader reader = await command.ExecuteReaderAsync();

        while (reader.Read())
        {
          _listStores.Add(new StoreFront()
          {
            StoreID = reader.GetGuid(0),
            StoreName = reader.GetString(1),
            StoreLocation = reader.GetString(2)
          });
        }
      }

      return _listStores;
    }




    public async Task<StoreFront> UpdateStore(StoreFront b_store)
    {
            string _sqlQuery = @"UPDATE StoreFront
                          SET storeName=@storeName, storeLocation=@storeLocation
                          WHERE storeID=@storeID;";

      using (SqlConnection conn = new SqlConnection(_connectionStrings))
      {
        await conn.OpenAsync();

        SqlCommand command = new SqlCommand(_sqlQuery, conn);

        command.Parameters.AddWithValue("@storeName", b_store.StoreName);
        command.Parameters.AddWithValue("@storeLocation", b_store.StoreLocation);
        command.Parameters.AddWithValue("@storeID", b_store.StoreID);

        await command.ExecuteNonQueryAsync();
      }

      return b_store;
    }
}
    }
