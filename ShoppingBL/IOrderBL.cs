 using ShoppingModel;

namespace ShoppingBL
{
    public interface IOrderBL
    {   
        Task<Order> PlaceOrder(Order b_order);
        Task<Order> UpdateOrder(Order b_order);
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrderByOrderID(Guid b_orderID);
        Task<List<LineItem>> GetLineItemsByOrderID(Guid b_orderID);
        Task<List<Order>> GetAllOrdersByCustomerID(Guid b_customerID);
        Task<List<Order>> GetAllOrdersByStoreID(Guid b_storeID);
        Task<List<LineItem>> AddLineItemsToOrder(Order b_order);
        Task<Order> GetOrderbyPrice();
        
    }
}
     
     
