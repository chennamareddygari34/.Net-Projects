using ProductAPI.Interfaces;
using ProductAPI.Models;


namespace ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<int, Product> _productRepository;
        public ProductService(IRepository<int, Product> productRepo)
        {
            _productRepository = productRepo;
        }
        public Product AddANewProduct(Product product)
        {
            return _productRepository.Add(product);
        }
        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }
    }
}
