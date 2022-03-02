namespace ShoppingModel
{
  public class Inventory
  {
    public Guid StoreID { get; set; }
    public Guid ProductID { get; set; }
    public int ProductQuantity { get; set; }
    
    public Inventory()
    {
      StoreID = Guid.NewGuid();
      ProductID = Guid.NewGuid();
      ProductQuantity = 0;
    }
  }
}