using LoanApp.Interfaces;
using LoanApp.Models;

namespace LoanApp.Services
{
    public class CarLoanService : ICarLoanService
    {
        public CarLoanResponse GetCarLoanDetails(CarLoanRequest request)
        {
            var loanAmount = (int)(request.CarPrice * 0.8);
            return new CarLoanResponse
            {
                ApplicableLoanAmount = loanAmount,
                InterestRate = 8,
                TenureInYears = 2
            };
        }
    }
}
