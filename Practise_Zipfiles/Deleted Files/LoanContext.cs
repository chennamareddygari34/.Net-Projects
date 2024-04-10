using LoanApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanApp.Contexts
{
    public class LoanContext : DbContext
    {
        public LoanContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<BikeLoanRequest> bikeloanrequest { get; set; }
        public DbSet<CarLoanRequest> carloanrequest { get; set; }
       


    }

}
    

