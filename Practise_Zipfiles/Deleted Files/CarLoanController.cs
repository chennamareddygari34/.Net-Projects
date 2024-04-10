using LoanApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanApp.Controllers
{
    //[Route("api/v2/[controller]")]
    [ApiVersion("2.0")]
    [Route("api/{version:apiVersion}/[controller]")]
    [ApiController]
    public class CarLoanController : ControllerBase
    {
        [HttpPost]
        public IActionResult GetLoanDetails(CarLoanRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loanAmount = (int)(request.CarPrice * 0.8);
            var interestRate = 8;
            var tenure = 5;

            var response = new CarLoanResponse
            {
                ApplicableLoanAmount = loanAmount,
                InterestRate = interestRate,
                TenureInYears = tenure
            };

            return Ok(response);
        }
    }
}

