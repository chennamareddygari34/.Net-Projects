using BankAcountEstatementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAcountEstatementApp.Contexts
{
    public class EStatementContext:DbContext
    {
        public EStatementContext(DbContextOptions options):base(options) 
        {
            
        }
        public DbSet<User> users { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Statement> statements { get; set; }
       public DbSet<Currency> currency { get; set; }

        public DbSet<Transaction> transactions { get; set; }
        public DbSet<AccountsStatements> AccountsStatements { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountsStatements>()
                .HasKey(op => new { op.StatementId, op.AccountNumber });

            
        }

    }
}
