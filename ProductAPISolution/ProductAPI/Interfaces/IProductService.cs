using ProductAPI.Models;

namespace ProductAPI.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product AddANewProduct(Product product);
    }
}
