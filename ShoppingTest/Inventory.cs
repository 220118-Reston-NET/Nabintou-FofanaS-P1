using System.Collections.Generic;
using Moq;
using ShoppingBL;
using ShoppingDL;
using ShoppingModel;
using Xunit;
using Moq;
using System.Threading.Tasks;
using System;

namespace Test
{
  public class InventoryTest
  {
    [Fact]
    public async Task Should_Get_All_Inventory_From_Store()
    {
      // Arrange
      List<Inventory> _expectedListOfInventory = new List<Inventory>();
      _expectedListOfInventory.Add(new Inventory()
      {
        ProductID = Guid.Parse("3FA85F64-5717-4562-B3FC-2C963F66AFA6"),
        StoreID = Guid.Parse("3FA85F64-5717-4562-B3FC-2C963F66AFA6"),
        ProductQuantity = 22
      });

      Mock<IRepository_v> _mockRepo = new Mock<IRepository_v>();
      _mockRepo.Setup(repo => repo.GetAllInventory()).ReturnsAsync(_expectedListOfInventory);
      IInventoryBL _inventoryBL = new InventoryBL(_mockRepo.Object);

      // Act
     List<Inventory> _actualListOfInventory = await _inventoryBL.GetStoreInventoryByStoreID(Guid.Parse("3FA85F64-5717-4562-B3FC-2C963F66AFA6"));

      // Assert
      Assert.Equal(_expectedListOfInventory[0].StoreID, _actualListOfInventory[0].StoreID);
    }

    [Fact]
    public async Task Should_Get_All_Inventory()
    {
      // Arrange
      List<Inventory> _expectedListOfInventory = new List<Inventory>();
      _expectedListOfInventory.Add(new Inventory()
      {
        ProductID = Guid.Parse("3FA85F64-5717-4562-B3FC-2C963F66AFA6"),
        StoreID = Guid.Parse("3FA85F64-5717-4562-B3FC-2C963F66AFA6"),
        ProductQuantity = 10
      });

       Mock<IRepository_v> _mockRepo = new Mock<IRepository_v>();
      _mockRepo.Setup(repo => repo.GetAllInventory()).ReturnsAsync(_expectedListOfInventory);
      IInventoryBL _inventoryBL = new InventoryBL(_mockRepo.Object);

      // Act
      List<Inventory> _actualListOfInventory = await _inventoryBL.GetAllInventory();

      // Assert
      Assert.Same(_expectedListOfInventory, _actualListOfInventory);
    }

    




    [Fact]
    public async Task Should_Not_Import_New_Product_To_Store()
    {
      // Arrange
      List<Inventory> _expectedListOfInventory = new List<Inventory>();
      _expectedListOfInventory.Add(new Inventory()
      {
        ProductID = Guid.Parse("3FA85F64-5717-4562-B3FC-2C963F66AFA6"),
        StoreID = Guid.Parse("3FA85F64-5717-4562-B3FC-2C963F66AFA6"),
        ProductQuantity = 5
      });

      Mock<IRepository_v> _mockRepo = new Mock<IRepository_v>();
      _mockRepo.Setup(repo => repo.GetAllInventory()).ReturnsAsync(_expectedListOfInventory);
      IInventoryBL _inventoryBL = new InventoryBL(_mockRepo.Object);


      Inventory _newInventory = new Inventory();
      // Act & Assert
      // Shouldn't import this product to store due to the it is existing in the store
      await Assert.ThrowsAsync<System.Exception>(
        async () => _newInventory = await _inventoryBL.AddInventory(new Inventory()
        {
          ProductID = Guid.Parse("3FA85F64-5717-4562-B3FC-2C963F66AFA6"),
        StoreID = Guid.Parse("3FA85F64-5717-4562-B3FC-2C963F66AFA6"),
        ProductQuantity = 50
        })
      );
    }
  }
}