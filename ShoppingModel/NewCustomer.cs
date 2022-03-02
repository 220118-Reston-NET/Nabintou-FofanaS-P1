namespace ShoppingModel
{
public class NewCustomer
{
    public Guid CustomerID { get; set;}
    public string CustomerName { get; set; }
    public string CustomerAddress { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerUsername { get; set; }
    public string CustomerPassword { get; set; }
    public DateTime CreatedAt { get; set; }
    
        //Default constructor to add default values to the properties
        public NewCustomer()
        {
            CustomerID = Guid.NewGuid();
            CustomerName = "";
            CustomerAddress = "";
            CustomerEmail = "";
            CustomerUsername = "";
            CustomerPassword = "";
           
        }
    }
}
