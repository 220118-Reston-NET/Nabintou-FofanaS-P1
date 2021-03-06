using ShoppingModel;
using ShoppingDL;

namespace ShoppingBL
{
    public class ProductBL : IProductBL
    {

        private readonly IRepository_p _productRepo;
        public ProductBL(IRepository_p b_productRepo)
        {
            _productRepo = b_productRepo;
        }


        public Product AddProduct(Product b_product)
        {
         List<Product> listOfProduct = _productRepo.GetAllProduct();
         return _productRepo.AddProduct(b_product);
        }
            

        public List<Product> GetAllProduct()
        {
           return _productRepo.GetAllProduct();
        }



        public List<Product> GetProductByStoreID(Guid b_storeID)
        {
            return _productRepo.GetProductByStoreID(b_storeID);
        }


        public Product GetProductDetail(Guid b_productID)
        {
             List<Product> _listOfProduct = GetAllProduct();

            return _listOfProduct.Where(p => p.ProductID == b_productID).First();
        }


        public List<Product> SearchProduct(string p_name)
        {
            {
           
            List<Product> listOfProduct = _productRepo.GetAllProduct();
            return listOfProduct
                        .Where(product => product.ProductName.Contains(p_name)) 
                        .ToList(); 
           }
        }


         public Product UpdateProduct(Product b_product)
         {
            List<Product> listOfProduct = GetAllProduct()
                                       .Where(p => p.ProductID != b_product.ProductID).ToList();
            if (listOfProduct.Any(product => product.ProductName == b_product.ProductName))
            {
            throw new Exception("Already in the store database!");
            }
            return _productRepo.UpdateProduct(b_product);
        }
    }
}

        