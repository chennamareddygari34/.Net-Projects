using LoanApp.Models;

namespace LoanApp.Services
{
    public interface IBikeLoanService
    {
        public List<BikeLoanRequest> GetBikeLoan();

    }
}