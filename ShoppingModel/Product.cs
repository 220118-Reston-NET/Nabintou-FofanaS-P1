namespace ShoppingModel
{
public class Product
{
    public Guid ProductID { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public decimal ProductPrice { get; set; }
    public DateTime createdAt { get; set; }
    
        //Default constructor to add default values to the properties
        public Product()
        {
            ProductID = Guid.NewGuid();
            ProductName = "";
            ProductDescription = "";
            ProductPrice = 0;
            createdAt = DateTime.Now;
        }
    }
}
