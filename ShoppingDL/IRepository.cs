global using ShoppingModel;
namespace ShoppingDL
{
    public interface IRepository_c
    {
        NewCustomer AddCustomer(NewCustomer b_customer);
        List<ReturningCustomer> GetAllCustomerOld();
        List<ReturningCustomer> GetAllCustomers();
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
        Task<List<Order>> GetAllOrdersByCustomerID(Guid b_customerID);
        Task<List<Order>> GetAllOrdersByStoreID(Guid b_storeID);
        Task<Order> GetOrderbyPrice();
        
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
        List<Product> GetProductByStoreID(Guid b_storeID);
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


    public interface IRepository_cart
    {
        Task<LineItem> AddLineItem(LineItem b_item);
    }

}