//using ShopDL;
namespace ShoppingModel
{
public class Order
{
    public Guid OrderID { get; set; } 
    public Guid CustomerID { get; set; }
    public Guid StoreID { get; set; }
    public List<LineItem> _Lineitem;
    public List<LineItem> ShoppingCart
        {
            get { return _Lineitem; }
            set 
            { 
                _Lineitem = value;
            }
        }
   
    public decimal TotalPrice { get; set; }
    public DateTime createdAt { get; set; }
    

    public Order()
        {
            OrderID = Guid.NewGuid();
            CustomerID = Guid.NewGuid();
            StoreID = Guid.NewGuid();
            ShoppingCart = new List<LineItem>(){new LineItem()};    
            TotalPrice = 0;
            createdAt = DateTime.Now;
        }

    }
}
