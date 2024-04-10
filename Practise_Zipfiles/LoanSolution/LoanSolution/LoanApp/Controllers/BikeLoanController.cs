using LoanApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanApp.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BikeLoanControllerV1 : ControllerBase

    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This is the GET method for BikeLoanController v1.0");
        }
        [HttpPost]
        public IActionResult GetLoanDetails(BikeLoanRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loanAmount = (int)(request.BikePrice * 0.2);
            var interestRate = 8;
            var tenure = 2;

            var response = new BikeLoanResponse
            {
                ApplicableLoanAmount = loanAmount,
                InterestRate = interestRate,
                TenureInYears = tenure
            };

            return Ok(response);
            Console.WriteLine("Loan request processed successfully in v1.0");
        }
    }
}

