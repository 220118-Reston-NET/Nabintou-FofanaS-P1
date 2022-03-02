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
    public async Task Should_Get_All_StoreFronts()
    {
      // Arrange
      List<StoreFront> _expectedListOfStoreFronts = new List<StoreFront>();
      _expectedListOfStoreFronts.Add(new StoreFront()
      {
        StoreID = Guid.NewGuid(),
        StoreName = "MO",
        StoreLocation = "Dallas, TX"
      });

      Mock<IRepository_s> _mockRepo = new Mock<IRepository_s>();
      _mockRepo.Setup(repo => repo.GetAllStore()).ReturnsAsync(_expectedListOfStoreFronts);
      IStoreBL _storeList = new StoreBL(_mockRepo.Object);

      // Act
      List<StoreFront> _actualListOfStoreFronts = await _storeList.GetAllStore();

      // Assert
      Assert.Same(_expectedListOfStoreFronts, _actualListOfStoreFronts);
      Assert.Equal(_expectedListOfStoreFronts[0].StoreName, _actualListOfStoreFronts[0].StoreName);
    }



     [Fact]
    public async Task Should_Get_StoreFront_That_Have_Name_Matched()
    {
      // Arrange
      List<StoreFront> _expectedStore = new List<StoreFront>();
      StoreFront store_1 = new StoreFront()
      {
        StoreID = Guid.NewGuid(),
        StoreName = "Karlaa",
        StoreLocation = "Dallas, TX"
      };
      StoreFront store_2 = new StoreFront()
      {
        StoreID = Guid.NewGuid(),
        StoreName = "KarGoods",
        StoreLocation = "Newark, NJ"
      };
      _expectedStore.Add(store_1);
      _expectedStore.Add(store_2);

      Mock<IRepository_s> _mockRepo = new Mock<IRepository_s>();
      _mockRepo.Setup(repo => repo.GetAllStore()).ReturnsAsync(_expectedStore);
      IStoreBL _storeList = new StoreBL(_mockRepo.Object);

      // Act
      List<StoreFront> _actualStore = await _storeList.SearchStoreByName("Kar");

      // Assert
      Assert.Equal(_expectedStore, _actualStore);
    }
    


    [Fact]
    public async Task Should_Not_Add_New_StoreFront()
    {
      // Arrange
      List<StoreFront> _expectedListOfStoreFronts = new List<StoreFront>();
      _expectedListOfStoreFronts.Add(new StoreFront()
      {
        StoreID = Guid.NewGuid(),
        StoreName = "Karlaa",
        StoreLocation = "Dallas, TX"
      });


      
      
      
      Mock<IRepository_s> _mockRepo = new Mock<IRepository_s>();
      _mockRepo.Setup(repo => repo.GetAllStore()).ReturnsAsync(_expectedListOfStoreFronts);
      IStoreBL _storeList = new StoreBL(_mockRepo.Object);

      StoreFront _newStoreF = new StoreFront();

      // Act & Assert
      await Assert.ThrowsAsync<System.Exception>(
        async () => _newStoreF = await _storeList.AddNewStoreFront(new StoreFront()
        {
          StoreID = Guid.NewGuid(),
          StoreName = "Karlaa",
          StoreLocation = "Dallas, TX"
        })
      );
    }
    }
}