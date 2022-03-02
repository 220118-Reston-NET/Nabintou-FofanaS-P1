namespace ShoppingModel
{
public class Store
{

    public Guid StoreID { get; set; }
    public string StoreName { get; set; }
    public string StoreLocation { get; set; }
        


     public Store()
        {
            StoreID = Guid.Empty;
            StoreName = "";
            StoreLocation = "";
            
        }
}
}
