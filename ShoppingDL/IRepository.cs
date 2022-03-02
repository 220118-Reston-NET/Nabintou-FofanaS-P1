global using ShoppingModel;
namespace ShoppingDL
{
    /*
    public interface IRepository<T>
    {
        T Add(T b_customer);

        List<T> GetAll();

        T Update(T b_customer);

        T Delete(T b_customer);
    }
    */
    public interface IRepository_c
    {
    /// <summary>
        /// Add a pokemon to the database
        /// </summary>
        /// <param name="b_customer">This the pokemon object we are adding to the database</param>
        /// <returns>Returns the pokemon that was added</returns>
        NewCustomer AddCustomer(NewCustomer b_customer);
      

        //ReturningCustomer LoginCustomer(ReturningCustomer b_customer);
        /// <summary>
        /// Will give all pokemon in the database
        /// </summary>
        /// <returns>Returns a list collection of Pokemon objects</returns>
        List<ReturningCustomer> GetAllCustomerOld();

        List<ReturningCustomer> GetAllCustomers();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b_customer"></param>
        /// <returns></returns>
        ReturningCustomer UpdateCustomer(ReturningCustomer b_customer);

        
        ReturningCustomer DeleteCustomer(ReturningCustomer b_customer);
}

 public interface IRepository_o
    {
        Task<Order> PlaceOrder(Order b_order);
        Task<List<Order>> GetAllOrders();
        Task<List<LineItem>> AddLineItemsToOrder(Order b_order);
        Task SubstractInventoryAfterPlacedOrder(Order b_order);
        Task<List<LineItem>> GetLineItemsByOrderID(Guid b_orderID);
        Task<Order> UpdateOrder(Order b_order);
    }

    public interface IRepository_s
    {
        Task<StoreFront> AddNewStoreFront(StoreFront b_store);
        Task<StoreFront> UpdateStore(StoreFront b_store);
        Task<List<StoreFront>> GetAllStore();
        
    }

    public interface IRepository_a
    {
        Admin AddAdmin(Admin b_admin);
        List<Admin> GetAllAdmin();
    }

    public interface IRepository_p
    {
        Product AddProduct(Product b_product);
        
        List<Product> GetAllProduct();
        List<Product> GetAllProductsFromStore(Guid b_storeID);
        List<StoreFront> GetAllStoreFrontsByProductID(Guid b_productID);
        List<Product> SearchProduct(string p_name); 
        Product GetProductDetail(Guid b_productID);
        Product UpdateProduct(Product b_product);

    }

     public interface IRepository_v
    {
        Task<Inventory> AddInventory(Inventory b_inven);
        Task ReplenishInventoryByID(Inventory b_inven);
        Task<List<Inventory>> GetAllInventory();
    }

}