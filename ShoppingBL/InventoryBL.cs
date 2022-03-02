using ShoppingModel;
using ShoppingDL;
using ShoppingBL;

namespace ShoppingBL
{
    public class InventoryBL: IInventoryBL
    {
        private IRepository_v _invenRepo;

        public InventoryBL(IRepository_v b_invRepo)
        {
            _invenRepo = b_invRepo;
        }

    public async Task<Inventory> GetInventory(Inventory b_inven)
    {

      List<Inventory> _listOfInventory = await GetAllInventory();
      return _listOfInventory.Find(p => p.ProductID.Equals(b_inven.ProductID) && p.StoreID.Equals(b_inven.StoreID));
   
    }


     public async Task<List<Inventory>> GetAllInventory()
    {
      return await _invenRepo.GetAllInventory();
    }


    public async Task<Inventory> AddInventory(Inventory b_inven)
    {

      List<Inventory> _listOfInventory = await GetStoreInventoryByStoreID(b_inven.StoreID);
      if (_listOfInventory.Any(p => p.ProductID.Equals(b_inven.ProductID)))
      {
        throw new Exception("Cannot import this product due to it already in the store! Please check the inventory!");
      }
      return await _invenRepo.AddInventory(b_inven);

    }

    public async Task<List<Inventory>> GetStoreInventoryByStoreID(Guid b_storeID)
    {

      List<Inventory> _listOfInventory = await GetAllInventory();
      return _listOfInventory.FindAll(p => p.StoreID.Equals(b_storeID));

    }
  
    public async Task ReplenishInventoryByID(Inventory b_inven)
    {

      await _invenRepo.ReplenishInventoryByID(b_inven);

    }
  }
}

