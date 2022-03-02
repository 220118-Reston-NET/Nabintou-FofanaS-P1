using ShoppingModel;

namespace ShoppingBL
{
    public interface IAdminBL
    {
        Admin AddAdmin(Admin b_admin);
        Admin Login(AdminLogin b_admin);
        List<Admin> GetAllAdmin();
    }
}