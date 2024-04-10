using LoanApp.Models;

namespace LoanApp.Interfaces
{
    public interface IBusLoanService
    {
        BusLoanResponse GetBusLoanDetails(BusLoanRequest request);

    }
}
