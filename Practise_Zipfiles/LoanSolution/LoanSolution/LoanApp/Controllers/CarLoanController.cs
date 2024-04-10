using LoanApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanApp.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v2/[controller]")]
    [ApiController]
    public class CarLoanControllerV2 : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This is the GET method for CarLoanController v1.0");
        }
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

