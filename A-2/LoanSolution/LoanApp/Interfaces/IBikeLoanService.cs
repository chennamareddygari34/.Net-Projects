using LoanApp.Models;

namespace LoanApp.Interfaces
{
    public interface IBikeLoanService
    {
        BikeLoanResponse GetBikeLoanDetails(BikeLoanRequest request);

    }
}
