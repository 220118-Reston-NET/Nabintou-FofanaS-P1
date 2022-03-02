using ShoppingModel;

namespace ShoppingBL
{
    public interface IProductBL
    {   
        Product AddProduct(Product b_product);
        List<Product> GetAllProduct();
        List<Product> GetAllProductsFromStore(Guid b_storeID);
        List<StoreFront> GetAllStoreFrontsByProductID(Guid b_productID);
        List<Product> SearchProduct(string p_name); 
        Product GetProductDetail(Guid b_productID);
        Product UpdateProduct(Product b_product);
    }
}