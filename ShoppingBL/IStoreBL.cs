 using ShoppingModel;

namespace ShoppingBL
{
    public interface IStoreBL
    {
    Task<StoreFront> AddNewStoreFront(StoreFront b_store);
    Task<StoreFront> GetStoreByID(Guid b_storeID);
    Task<StoreFront> UpdateStore(StoreFront b_store);
    Task<List<StoreFront>> GetAllStore();
    Task<List<StoreFront>> SearchStoreByName(string b_storeName);
    }
}