namespace ShoppingModel
{
public class ReturningCustomer
{
    public Guid CustomerID { get; set;}
    public string CustomerName { get; set; }
    public string CustomerAddress { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerUsername { get; set; }
    public string CustomerPassword { get; set; }
    private List<Order> _orders { get; set; }
    public List<Order> Orders
        {
            get { return _orders; }
            set 
            { 
                _orders = value;
            }
        }
    
        //Default constructor to add default values to the properties
        public ReturningCustomer()
        {
            CustomerID = Guid.NewGuid();
            CustomerName = "";
            CustomerAddress = "";
            CustomerEmail = "";
            CustomerUsername = "";
            CustomerPassword = "";
            
             _orders = new List<Order>()
            {
                new Order()
            };
            
        }
       
    }
}
