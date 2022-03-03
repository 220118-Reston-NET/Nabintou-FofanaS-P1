using ShoppingModel;
using ShoppingDL;

namespace ShoppingBL
{
    public class StoreBL: IStoreBL
    {
        private readonly IRepository_s _storeRepo;

        public StoreBL(IRepository_s b_storeRepo)
        {
            _storeRepo = b_storeRepo;
        }

        public async Task<StoreFront> AddNewStoreFront(StoreFront b_store)
        {
            return await _storeRepo.AddNewStoreFront(b_store);
        }


        public async Task<List<StoreFront>> GetAllStore()
        {
            return await _storeRepo.GetAllStore();
        }


        public async Task<StoreFront> GetStoreByID(Guid b_storeID)
        {
            List<StoreFront> _listOfStoreFront = await GetAllStore();
            return _listOfStoreFront.Find(p => p.StoreID.Equals(b_storeID));
        }


        public async Task<List<StoreFront>> SearchStoreByName(string b_storeName)
        {
           List<StoreFront> _listOfStoreFront = await GetAllStore();
           return _listOfStoreFront.FindAll(p => p.StoreName.Contains(b_storeName));
        }


        public async Task<StoreFront> UpdateStore(StoreFront b_store)
        {
            /*
             List<StoreFront> _listOfStoreFront = await GetAllStore();
             List<StoreFront> _listFilteredStore = _listOfStoreFront.FindAll(p => p.StoreID != b_store.StoreID);
             if (_listFilteredStore.Any(p => p.StoreName.Equals(b_store.StoreName)))
             {
             throw new Exception("Cannot update store front profile due to the name is existing in the system!");
             }
             */
         return await _storeRepo.UpdateStore(b_store);
        }
    }
}