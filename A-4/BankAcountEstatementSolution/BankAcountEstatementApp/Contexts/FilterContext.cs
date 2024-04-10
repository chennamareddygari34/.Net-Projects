using BankAcountEstatementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAcountEstatementApp.Contexts
{
    public class FilterContext : DbContext
    {
        public FilterContext(DbContextOptions options):base(options) 
        {
            
        }
        public DbSet<User> users { get; set; }
        public DbSet<Account> accounts { get; set; }
     

    }
}
