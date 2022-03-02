using Xunit;
using ShoppingModel;

namespace ShoppingTest;

public class AddAdminTest
{
    [Fact]
    public void AddAdmin()
    {
        //Arrange
        Admin testName = new Admin();
        string testNameVar = "MOISE";

        //Act
        testName.AdminName = testNameVar;

        //Assert
        Assert.NotNull(testName.AdminName);
        Assert.Equal(testNameVar, testName.AdminName);
    }
}
