using ShoppingModel;

namespace ShoppingBL
{
    public interface ICustomerBL
    {
        NewCustomer AddCustomer(NewCustomer b_customer);
        ReturningCustomer Login(CustomerLogin b_customer);
        ReturningCustomer UpdateCustomer(ReturningCustomer b_customer);
        List<ReturningCustomer> GetAllCustomerOld();
        List<ReturningCustomer> GetAllCustomers();
        ReturningCustomer DeleteCustomer(ReturningCustomer b_customerID);
        List<ReturningCustomer> SearchCustomer(string p_name);     
        
    }
}
     
     