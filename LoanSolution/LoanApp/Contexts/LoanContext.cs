using LoanApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanApp.Contexts
{
    public class LoanContext: DbContext
    {
        public LoanContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<BikeLoanRequest> bikeloanrequests { get; set; }
        public DbSet<CarLoanRequest> carloanrequests { get; set; }

        public DbSet<BusLoanRequest> busloanrequests { get; set; }
    }
}
