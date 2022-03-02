namespace ShoppingModel
{
public class Admin
{
    public Guid AdminID { get; set;}
    public string AdminName { get; set; }
    public string AdminEmail { get; set; }
    public string AdminUsername { get; set; }
    public string AdminPassword { get; set; }
    public DateTime CreatedAt { get; set; }
        public Admin()
        {
            AdminID = Guid.NewGuid();
            AdminName = "";
            AdminEmail = "";
            AdminUsername = "";
            AdminPassword = "";
            CreatedAt = DateTime.Now;
        }
    }
}
