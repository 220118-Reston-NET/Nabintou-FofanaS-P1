namespace ShoppingModel
{
public class StoreFront
{
    public Guid StoreID { get; set; }
    public string StoreName { get; set; }
    public string StoreLocation { get; set; }

     public StoreFront()
        {
            StoreID = Guid.NewGuid();
            StoreName = "";
            StoreLocation = "";
        }
    }
}
