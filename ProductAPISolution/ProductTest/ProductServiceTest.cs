using Microsoft.EntityFrameworkCore;
using ProductAPI.Context;
using ProductAPI.Interfaces;
using ProductAPI.Models;
using ProductAPI.Repositories;
using ProductAPI.Services;



namespace ProductTest
{
    public class ProductServiceTest
    {
        ProductContext context;




        [SetUp]
        public void Setup()
        {
            var dbContextOption = new DbContextOptionsBuilder<ProductContext>().UseInMemoryDatabase(databaseName: "dbDummyProduct").Options;
            context = new ProductContext(dbContextOption);
        }
        #region AddTest
        [Test]
        public void AddTest()
        {



            // Arrange
            IRepository<int, Product> productrepository = new ProductRepository(context);
            IProductService productservice = new ProductService(productrepository);





            //Action 
            var pro = new Product { Id = 1, Name = "ABC", Price = 200, Quantity = 120 };
            var result = productservice.AddANewProduct(pro);
            var data = new Product { Id = 3, Name = "ABC", Price = 200, Quantity = 120 };





            // Assert
            Assert.AreEqual(data.Id, result.Id);
        }
        #endregion



        #region GetAllProducts
        [Test]
        public void GetAllProduct()
        {
            IRepository<int, Product> productrepository = new ProductRepository(context);
            IProductService productservice = new ProductService(productrepository);
            Product product = new Product { Id = 3, Name = "DEF", Price = 200, Quantity = 120 };
            productrepository.Add(product);



            var result = productservice.GetAllProducts();



            Assert.NotNull(result);
            Assert.AreEqual(1, result.Count);



        }
        #endregion
    }
}
