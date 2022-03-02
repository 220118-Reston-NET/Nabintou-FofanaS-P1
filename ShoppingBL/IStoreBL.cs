 using ShoppingModel;

namespace ShoppingBL
{
    public interface IStoreBL
    {
         /// <summary>
    /// Add new store front profile
    /// </summary>
    /// <param name="b_store"></param>
    /// <returns></returns>
    Task<StoreFront> AddNewStoreFront(StoreFront b_store);

    /// <summary>
    /// Get Store Profile by store ID
    /// </summary>
    /// <param name="b_storeID"></param>
    /// <returns></returns>
    Task<StoreFront> GetStoreByID(Guid b_storeID);

    /// <summary>
    /// Update Store Profile
    /// </summary>
    /// <param name="b_store"></param>
    /// <returns></returns>
    Task<StoreFront> UpdateStore(StoreFront b_store);

    /// <summary>
    /// Get All Store Profiles in the system
    /// </summary>
    /// <returns></returns>
    Task<List<StoreFront>> GetAllStore();

    /// <summary>
    /// Search Stores By Store Name
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    Task<List<StoreFront>> SearchStoreByName(string b_storeName);
    }
}