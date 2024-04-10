using BankAcountEstatementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAcountEstatementApp.Contexts
{
    public class BankingContext:DbContext
    {
        public BankingContext(DbContextOptions options):base(options) 
        {
            
        }
        public DbSet<User> users { get; set; }
        public DbSet<Account> accounts { get; set; }
       

    }
}
