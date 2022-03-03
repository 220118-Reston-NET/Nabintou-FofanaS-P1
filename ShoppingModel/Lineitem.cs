namespace ShoppingModel
{
public class LineItem
{
     private static Product _product = new Product();
     public Guid ProductID { get; set; }
     public Guid OrderID { get; set; }
     public int ProductQuantity { get; set; }
     public decimal price;

   
        
     public LineItem()
        {
           ProductID = Guid.NewGuid();
           OrderID = Guid.NewGuid();
           ProductQuantity = 0;
           //price = _product.ProductPrice;
           price = 10;
        }     
   }
}