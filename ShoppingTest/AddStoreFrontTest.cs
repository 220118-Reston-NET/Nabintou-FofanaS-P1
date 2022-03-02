using Xunit;
using ShoppingModel;

namespace ShoppingTest;

public class AddStoreFrontTest
{
        [Fact]
        public void StoreFrontCheck()
        {
            //Arrange 
            StoreFront storeTest = new StoreFront();
            string testNameVar = "COCO";

            //Act
            storeTest.StoreName = testNameVar;

            //Assert
            Assert.Equal(testNameVar, storeTest.StoreName);
        }
}