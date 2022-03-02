namespace ShoppingModel
{
public class CustomerLogin
{
    public string CustomerUsername { get; set; }
    public string CustomerPassword { get; set; }
    
    
    
        //Default constructor to add default values to the properties
        public CustomerLogin()
        {
           
            CustomerUsername = "";
            CustomerPassword = "";
            
        }
    }
}
