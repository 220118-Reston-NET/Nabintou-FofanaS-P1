using System.Collections.Generic;
using System;
using Moq;
using ShoppingBL;
using ShoppingDL;
using ShoppingModel;
using Xunit;
using System.Threading.Tasks;

namespace StoreTest
{
    public class StoreBLTest
    {
        [Fact]
        public void Should_Get_All_Store()
        {
            //Arrange
            string StoreName = "Karlaa";
            string StoreLocation = "Dallas";

            StoreFront _store = new StoreFront()
            {
                StoreName = "Karlaa",
                StoreLocation = "Dallas"
            };

            List<StoreFront> expectedListOfStore = new List<StoreFront>();
            expectedListOfStore.Add(_store);

            //We are mocking one of the required dependencies of PokemonBL which is IRepository
            Mock<IRepository_s> mockRepo = new Mock<IRepository_s>();

            //We change that if our IRepository.GetAllPokemon() is called, it will always return our expectedListOfPoke
            //In this way, we guaranteed that our dependency will always work so if something goes wrong it is the business layer's fault
            mockRepo.Setup(StoreRepository => StoreRepository.GetAllStore()).Returns(expectedListOfStore);

            //We passed in the mock version of IRepository
            IStoreBL storeBL = new StoreBL(mockRepo.Object);

            //Act
            
            List<StoreFront> actualListOfStore = storeBL.GetAllStore();

            //Assert
            Assert.Same(expectedListOfStore, actualListOfStore); //Checks if both list are the same thing
            Assert.Equal(StoreName, actualListOfStore[0].StoreName); //Checks the first element of actualListOfPoke to have the same name
            Assert.Equal(StoreLocation, actualListOfStore[0].StoreLocation); //Checks the first element of actualListOfPoke to have teh same level
        }

    
    }
}