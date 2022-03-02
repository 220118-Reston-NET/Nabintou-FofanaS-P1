using ShoppingModel;

namespace ShoppingBL
{
    public interface IInventoryBL
    {
        Task<Inventory> AddInventory(Inventory p_inven);
        
        Task ReplenishInventoryByID(Inventory p_inven);

        Task<List<Inventory>> GetAllInventory();
        Task<Inventory> GetInventory(Inventory b_inven);

    }
}