 using ShoppingModel;

namespace ShoppingBL
{
    public interface IOrderBL
    {   
        //Order PlaceOrder(Order b_order);
        Task<Order> PlaceOrder(Order b_order);
        //List<Order> GetAllOrder();
        Task<Order> UpdateOrder(Order b_order);
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrderByOrderID(Guid b_orderID);
        Task<List<LineItem>> GetLineItemsByOrderID(Guid b_orderID);
        Task<List<Order>> GetAllOrdersByCustomerID(Guid b_customerID);
        
        Task<List<Order>> GetAllOrdersByStoreID(Guid b_storeID);
    }
}
     
     
