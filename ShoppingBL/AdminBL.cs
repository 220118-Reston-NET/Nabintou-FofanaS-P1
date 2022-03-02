using ShoppingModel;
using ShoppingDL;

namespace ShoppingBL
{
    public class AdminBL: IAdminBL
    {
        private IRepository_a _adminRepo;

        public AdminBL(IRepository_a b_adminRepo)
        {
            _adminRepo = b_adminRepo;
        }

        public Admin AddAdmin(Admin b_admin)
        {
            List<Admin> listOfAdmin = _adminRepo.GetAllAdmin();

            //Logic that checks if customer already exists
            if (listOfAdmin.Where(customer => customer.AdminUsername == b_admin.AdminUsername).Count() == 1)
            {
                throw new Exception("Customer email already exists!");
            }
            else if (b_admin.AdminUsername == null)
            {
                throw new Exception("Customer email was not defined!");
            }
            else
            {
                return _adminRepo.AddAdmin(b_admin);
            }
        }


        public Admin Login(AdminLogin b_admin)
        {
            List<Admin> listOfAdmin = _adminRepo.GetAllAdmin();

            Admin? found = listOfAdmin.FirstOrDefault(admin => admin.AdminUsername == b_admin.AdminUsername && admin.AdminPassword == b_admin.AdminPassword);
                 if (found == null)
            {
                throw new Exception("Not found!");
            }
           
            else
            {
                return found;

            }
        }

        public List<Admin> GetAllAdmin()
        {
            return _adminRepo.GetAllAdmin();
        }

    }
}