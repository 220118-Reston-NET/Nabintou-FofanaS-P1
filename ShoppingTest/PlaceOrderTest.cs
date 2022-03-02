/*using Xunit;
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
            //Arrange 
        List<Order> _ListOfOrders = new List<Order>();
        _ListOfOrders.Add(new Order()
        {
        OrderID = Guid.NewGuid(),
        StoreID = Guid.Parse("6575E291-0EAE-4251-90AA-E603DEBFC7EE"),
        StoreName = "Karlaa",
        TotalPrice = 233,
        createdAt = new DateTime(2022 - 02 - 09),
        CustomerID = Guid.Parse("3FA85F64-5717-4562-B3FC-2C963F66AFA1"),
        LineItem = new List<LineItem>()
        
      });

     
        //Arrange
        Order test_listOfOrder = new Order();
        string testNameVar = "Karlaa";
        Guid testStoreIDVar = Guid.Parse("6575E291-0EAE-4251-90AA-E603DEBFC7EE");
      
         //Act
        test_listOfOrder.StoreName = testNameVar;
        test_listOfOrder.StoreID = testStoreIDVar;

        //Assert
        Assert.NotNull(test_listOfOrder.StoreName);
        Assert.Equal(testNameVar, test_listOfOrder.StoreName);
 
        Assert.NotNull( test_listOfOrder.StoreID);
        Assert.Equal(testStoreIDVar, test_listOfOrder.StoreID);
        }
}

   
}*/