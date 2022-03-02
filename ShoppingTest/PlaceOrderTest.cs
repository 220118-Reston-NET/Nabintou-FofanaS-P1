using Xunit;
using ShoppingModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;


namespace ShoppingTest{

public class PlaceOrderTest
{
        [Fact]
        public async Task PlaceOrder()
        {
          
        List<Order> _ListOfOrders = new List<Order>();
        _ListOfOrders.Add(new Order()
        {
        OrderID = Guid.NewGuid(),
        StoreID = Guid.Parse("6575E291-0EAE-4251-90AA-E603DEBFC7EE"),
        CustomerID = Guid.NewGuid(),
        TotalPrice = 500,
        createdAt = new DateTime(2022 - 02 - 09),
        ShoppingCart = new List<LineItem>()
        
      });

     
       
        Order test_listOfOrder = new Order();
        string testNameVar = "Karlaa";
        Guid testStoreIDVar = Guid.Parse("6575E291-0EAE-4251-90AA-E603DEBFC7EE");
      
         
       
        test_listOfOrder.StoreID = testStoreIDVar;

        
        
        Assert.NotNull( test_listOfOrder.StoreID);
        Assert.Equal(testStoreIDVar, test_listOfOrder.StoreID);
        }
}
}

   
