using ShoppingModel;
using ShoppingDL;

namespace ShoppingBL
{
    public class CustomerBL: ICustomerBL
    {
        private readonly IRepository_c _customerRepo;

        public CustomerBL(IRepository_c b_customerRepo)
        {
            _customerRepo = b_customerRepo;
        }

        
        public NewCustomer AddCustomer(NewCustomer b_customer)
        {
            List<ReturningCustomer> listOfCustomer = _customerRepo.GetAllCustomerOld();

            
            if (listOfCustomer.Where(customer => customer.CustomerEmail == b_customer.CustomerEmail).Count() == 1)
            {
                throw new Exception("Customer email already exists!");
            }
            else if (b_customer.CustomerEmail == null)
            {
                throw new Exception("Customer email was not defined!");
            }
            else
            {
                return _customerRepo.AddCustomer(b_customer);
            }
        }



        public ReturningCustomer Login(CustomerLogin b_customer)
        {
            List<ReturningCustomer> listOfCustomer = _customerRepo.GetAllCustomerOld();

            ReturningCustomer? found = listOfCustomer.FirstOrDefault(customer => customer.CustomerUsername == b_customer.CustomerUsername && customer.CustomerPassword == b_customer.CustomerPassword);
               if (found == null)
            {
                throw new Exception("Not found!");
            }
           
            else
            {
                return found;

            }
        }


        public List<ReturningCustomer> GetAllCustomers()
        {
            return _customerRepo.GetAllCustomerOld();
        }

        public List<ReturningCustomer> GetAllCustomerOld()
        {
            return _customerRepo.GetAllCustomerOld();
        }

        
        public ReturningCustomer GetCustomerByID(Guid b_customerID)
        {
           return GetAllCustomerOld().Find(customer => customer.CustomerID.Equals(b_customerID));
        }
       

        public ReturningCustomer UpdateCustomer(ReturningCustomer b_customer)
        {

            List<ReturningCustomer> listOfCustomer = GetAllCustomerOld().Where(b => b.CustomerID != b_customer.CustomerID).ToList();
            if (listOfCustomer.Any(customer => customer.CustomerEmail == b_customer.CustomerEmail))
            {
            throw new Exception("Already in the store database!");
            }
            return _customerRepo.UpdateCustomer(b_customer);

        }

        public ReturningCustomer DeleteCustomer(ReturningCustomer b_customerID)
        {
            return _customerRepo.DeleteCustomer(b_customerID);
        }

   
        public List<ReturningCustomer> SearchCustomer(string p_name)
        {
             {
            List<ReturningCustomer> listOfCustomer = _customerRepo.GetAllCustomerOld();

           
            return listOfCustomer
                        .Where(customer => customer.CustomerName.Contains(p_name)) 
                        .ToList(); 
         
            }
        }

        public List<ReturningCustomer> GetAllCustomer()
        {
            throw new NotImplementedException();
        }

        public NewCustomer Login(NewCustomer b_customer)
        {
            throw new NotImplementedException();
        }

        
    }
        
    }
    
