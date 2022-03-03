using ShoppingModel;

namespace ShoppingBL
{
    public interface IProductBL
    {   
        Product AddProduct(Product b_product);
        List<Product> GetAllProduct();
        List<Product> GetProductByStoreID(Guid b_storeID);
        List<Product> SearchProduct(string p_name); 
        Product GetProductDetail(Guid b_productID);
        Product UpdateProduct(Product b_product);
    }
}