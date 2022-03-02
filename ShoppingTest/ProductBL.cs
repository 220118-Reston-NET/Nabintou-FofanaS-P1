using System.Collections.Generic;
using Moq;
using ShoppingBL;
using ShoppingDL;
using ShoppingModel;
using Xunit;

namespace ProductTest
{
    public class ProductBLTest
    {
        [Fact]
        public void Should_Get_All_Product()
        {
            //Arrange
            
            string ProductName = "Soap";
            decimal ProductPrice = 100;

            Product _p1= new Product()
            {
                    ProductName = "Soap",
                    ProductPrice = 100
            };

            List<Product> expectedListOfProduct = new List<Product>();
            expectedListOfProduct.Add(_p1);

            
            Mock<IRepository_p> mockRepo = new Mock<IRepository_p>();

            
            mockRepo.Setup(ProductRepository => ProductRepository.GetAllProduct()).Returns(expectedListOfProduct);

            //We passed in the mock version of IRepository
            IProductBL productBL = new ProductBL(mockRepo.Object);

            //Act
            List<Product> actualListOfProduct = productBL.GetAllProduct();

            //Assert
            Assert.Same(expectedListOfProduct, actualListOfProduct); //Checks if both list are the same thing
            Assert.Equal(ProductName, actualListOfProduct[0].ProductName); //Checks the first element of actualListOfProduct to have the same name
            Assert.Equal(ProductPrice, actualListOfProduct[0].ProductPrice); //Checks the first element of actualListOfProduct to have teh same price
        }

    
    }
}