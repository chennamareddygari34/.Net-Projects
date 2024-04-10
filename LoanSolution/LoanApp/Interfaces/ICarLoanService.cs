using System.Security.Principal;
using LoanApp.Models;

namespace LoanApp.Interfaces
{
    public interface ICarLoanService
    {

        CarLoanResponse GetCarLoanDetails(CarLoanRequest request);

    }
}
