namespace ShoppingModel
{
public class LineItem
{
     public Guid ProductID { get; set; }
     public Guid OrderID { get; set; }
     public int ProductQuantity { get; set; }
     public decimal price;

   
        
     public LineItem()
        {
           ProductID = Guid.NewGuid();
           OrderID = Guid.NewGuid();
           ProductQuantity = 0;
           price = 10;
        }     
   }
}