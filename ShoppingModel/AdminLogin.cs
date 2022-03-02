namespace ShoppingModel
{
public class AdminLogin
{
    public string AdminUsername { get; set; }
    public string AdminPassword { get; set; }
    
        //Default constructor to add default values to the properties
        public AdminLogin()
        {
            AdminUsername = "";
            AdminPassword = "";
        }
    }
}
