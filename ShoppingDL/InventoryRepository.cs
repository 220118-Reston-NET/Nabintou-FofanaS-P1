using System.Data.SqlClient;

namespace ShoppingDL
{
    public class InventoryRepository : IRepository_v
    {
        private readonly string _connectionStrings;
        public InventoryRepository(string p_connectionStrings)
        {
            _connectionStrings = p_connectionStrings;
        }

    public async Task<List<Inventory>> GetAllInventory()
    {
      string _sqlQuery = @"SELECT storeID, productID, productQuantity
                          FROM Inventory;";
      List<Inventory> _listInventory = new List<Inventory>();

      using (SqlConnection conn = new SqlConnection(_connectionStrings))
      {
        await conn.OpenAsync();

        SqlCommand command = new SqlCommand(_sqlQuery, conn);

        SqlDataReader reader = await command.ExecuteReaderAsync();

        while (reader.Read())
        {
          _listInventory.Add(new Inventory()
          {
            StoreID = reader.GetGuid(0),
            ProductID = reader.GetGuid(1),
            ProductQuantity = reader.GetInt32(2)
          });
        }
      }

      return _listInventory;
    }



     public async Task<Inventory> AddInventory(Inventory b_inven)
    {
      string _sqlQuery = @"INSERT INTO Inventory
                          
                          VALUES(@storeID, @productID, @productQuantity);";

      using (SqlConnection conn = new SqlConnection(_connectionStrings))
      {
        await conn.OpenAsync();

        SqlCommand command = new SqlCommand(_sqlQuery, conn);

        command.Parameters.AddWithValue("@storeID", b_inven.StoreID);
        command.Parameters.AddWithValue("@productID", b_inven.ProductID);
        command.Parameters.AddWithValue("@productQuantity", b_inven.ProductQuantity);

        await command.ExecuteNonQueryAsync();
      }

      return b_inven;
    }


      public async Task ReplenishInventoryByID(Inventory b_inven)
    {
      string _sqlQuery = @"UPDATE Inventory
                          SET productQuantity= productQuantity + @productQuantity
                          WHERE storeID=@storeID AND productID=@productID;";

      using (SqlConnection conn = new SqlConnection(_connectionStrings))
      {
        await conn.OpenAsync();

        SqlCommand command = new SqlCommand(_sqlQuery, conn);

        command.Parameters.AddWithValue("@productQuantity", b_inven.ProductQuantity);
        command.Parameters.AddWithValue("@storeID", b_inven.StoreID);
        command.Parameters.AddWithValue("@productID", b_inven.ProductID);

        await command.ExecuteNonQueryAsync();
      }
    }
    }


}
