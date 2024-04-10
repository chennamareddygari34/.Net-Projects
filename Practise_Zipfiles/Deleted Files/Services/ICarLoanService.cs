using LoanApp.Models;

namespace LoanApp.Services
{
    public interface ICarLoanService
    {
        public List<CarLoanRequest> GetCarLoan();

    }
}