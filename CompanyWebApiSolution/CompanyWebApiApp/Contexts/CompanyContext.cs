using CompanyApplication.Models;
using CompanyWebApiApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebApiApp.Contexts
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions opts) : base(opts)
        {

        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }

        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentNumber = 1, DepartmentName = "Operations" },
                new Department { DepartmentNumber = 2, DepartmentName = "HR" }
                );
        }


    }
    
}