using LoanApp.Interfaces;
using LoanApp.Models;

namespace LoanApp.Services
{
    public class BusLoanService : IBusLoanService
    {
        public BusLoanResponse GetBusLoanDetails(BusLoanRequest request)
        {
            var loanAmount = (int)(request.BusPrice * 0.8);
            return new BusLoanResponse
            {
                ApplicableLoanAmount = loanAmount,
                InterestRate = 8,
                TenureInYears = 2
            };
        }
    }
}
