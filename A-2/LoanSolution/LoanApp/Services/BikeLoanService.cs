using LoanApp.Interfaces;
using LoanApp.Models;

namespace LoanApp.Services
{
    public class BikeLoanService : IBikeLoanService
    {
        public BikeLoanResponse GetBikeLoanDetails(BikeLoanRequest request)
        {
            var loanAmount = (int)(request.BikePrice * 0.8);
            return new BikeLoanResponse
            {
                ApplicableLoanAmount = loanAmount,
                InterestRate = 8,
                TenureInYears = 2
            };
        }
    }
}
