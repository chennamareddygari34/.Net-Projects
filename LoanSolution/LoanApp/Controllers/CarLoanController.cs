using LoanApp.Interfaces;
using LoanApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoanApp.Controllers
{
    [ApiController]
   [ApiVersion("2.0")]
    [Route("api/v2/loan")]
    public class CarLoanController : ControllerBase
    {
        private readonly ICarLoanService _carloanService;
        public CarLoanController(ICarLoanService carloanService)
        {
            _carloanService = carloanService;
        }

       
        [HttpPost]
        public IActionResult GetLoanDetails(CarLoanRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loanDetails = _carloanService.GetCarLoanDetails(request);
            return Ok(loanDetails);
            
        }
    }
}

