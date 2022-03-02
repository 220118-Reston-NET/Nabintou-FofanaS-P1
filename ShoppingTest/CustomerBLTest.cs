/*using System.Collections.Generic;
using ShoppingBL;
using ShoppingDL;
using ShoppingModel;
using Xunit;


namespace CustomerTest
{
    public class CustomerBLTest
    {
        [Fact]
        public void Should_Get_All_Customer()
        {
            //Arrange
            string CustomerName = "Marc";
            string CustomerEmail = "marcus@gmail.com";

            ReturningCustomer customer = new ReturningCustomer()
            {
                CustomerName = "Marc",
                CustomerEmail = "marcus@gmail.com"
            };

            List<ReturningCustomer> expectedListOfCustomer = new List<ReturningCustomer>();
            expectedListOfCustomer.Add(customer);

            //We are mocking one of the required dependencies of PokemonBL which is IRepository
        
            Mock<IRepository_c> mockRepo = new Mock<IRepository_c>();

            //We change that if our IRepository.GetAllPokemon() is called, it will always return our expectedListOfPoke
            //In this way, we guaranteed that our dependency will always work so if something goes wrong it is the business layer's fault
            mockRepo.Setup(CustomerRepository => CustomerRepository.GetAllCustomerOld()).Returns(expectedListOfCustomer);

            //We passed in the mock version of IRepository
            ICustomerBL customerBL = new CustomerBL(mockRepo.Object);

            //Act
            List<ReturningCustomer> actualListOfCustomer = customerBL.GetAllCustomerOld();

            //Assert
            Assert.Same(expectedListOfCustomer, actualListOfCustomer); //Checks if both list are the same thing
            Assert.Equal(CustomerName, actualListOfCustomer[0].CustomerName); //Checks the first element of actualListOfPoke to have the same name
            Assert.Equal(CustomerEmail, actualListOfCustomer[0].CustomerEmail); //Checks the first element of actualListOfPoke to have teh same level
        }

    
    }
}*/