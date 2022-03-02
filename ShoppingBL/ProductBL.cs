using ShoppingModel;
using ShoppingDL;

namespace ShoppingBL
{
    public class ProductBL : IProductBL
    {

        private IRepository_p _productRepo;
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



        public List<Product> GetAllProductsFromStore(Guid b_storeID)
        {
            return _productRepo.GetAllProductsFromStore(b_storeID);
        }



        public List<StoreFront> GetAllStoreFrontsByProductID(Guid b_productID)
        {
            return _productRepo.GetAllStoreFrontsByProductID(b_productID);
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


            // LINQ library
            return listOfProduct
                        .Where(product => product.ProductName.Contains(p_name)) //Where method is designed to filter a collection based on a condition
                        .ToList(); //ToList method just converts into a list collection that our method needs to return
        
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

        