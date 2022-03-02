using Xunit;
using ShoppingModel;

namespace ShoppingTest;

public class AddCustomerTest
{
    [Fact]
    public void AddCustomer()
    {
        //Arrange
        ReturningCustomer testName = new ReturningCustomer();
        string testNameVar = "Joseph";

        //Act
        testName.CustomerName = testNameVar;

        //Assert
        Assert.NotNull(testName.CustomerName);
        Assert.Equal(testNameVar, testName.CustomerName);
    }
}
