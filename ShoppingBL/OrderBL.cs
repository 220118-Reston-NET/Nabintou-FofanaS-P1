using ShoppingModel;
using ShoppingDL;

namespace ShoppingBL
{
    public class OrderBL: IOrderBL
    {
        private readonly IRepository_o _orderRepo;

        public OrderBL(IRepository_o b_orderRepo)
        {
            _orderRepo = b_orderRepo;
        }

        
        public async Task<List<Order>> GetOrdersByStoreID(Guid p_storeID)
        {
            List<Order> _listOfOrder = await GetAllOrders();

            return _listOfOrder.FindAll(p => p.StoreID.Equals(p_storeID));
        }


        public async Task<Order> PlaceOrder(Order b_order)
        {
             return await _orderRepo.PlaceOrder(b_order);
        }

         public async Task<List<Order>> GetAllOrders()
        {
         return await _orderRepo.GetAllOrders();
        }

        public async Task<Order> GetOrderByOrderID(Guid b_orderID)
        {
         List<Order> _listOfOrder = await GetAllOrders();
        return _listOfOrder.Find(p => p.OrderID.Equals(b_orderID));
        }


      public async Task<Order> UpdateOrder(Order b_order)
      {
      Order _order = await GetOrderByOrderID(b_order.OrderID);

        return await _orderRepo.UpdateOrder(b_order);
      }

        
        public async Task<List<LineItem>> GetLineItemsByOrderID(Guid b_orderID)
        {
            return await _orderRepo.GetLineItemsByOrderID(b_orderID);
        }

        
        public async Task<List<Order>> GetAllOrdersByCustomerID(Guid b_customerID)
        {
            List<Order> _listOfOrder = await GetAllOrders();
            
           return _listOfOrder.FindAll(p => p.CustomerID.Equals(b_customerID));
        }



        public async Task<List<Order>> GetAllOrdersByStoreID(Guid b_storeID)
        {
         List<Order> _listOfOrder = await GetAllOrders();
        return _listOfOrder.FindAll(b => b.StoreID.Equals(b_storeID));
        }

        public async Task<List<LineItem>> AddLineItemsToOrder(Order b_order)
        {
            return await _orderRepo.AddLineItemsToOrder(b_order);
        }

        public Task<List<Order>> GetOrderbyPrice()
        {
            throw new NotImplementedException();
        }
    }
}
