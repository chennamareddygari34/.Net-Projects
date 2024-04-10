using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions opts) : base(opts)
        {

        }
        public DbSet<Product> products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Supplier>().HasKey(es => new { es.Id, es.Email });

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptops", Price = 25, Quantity = 5 },

                );


        }
    }
}
