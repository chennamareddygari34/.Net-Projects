using LoanApp.Interfaces;
using LoanApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanApp.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/loan")]
    public class BikeLoanController : ControllerBase
    {
        private readonly IBikeLoanService _bikeloanService;
        public BikeLoanController(IBikeLoanService bikeloanService)
        {
            _bikeloanService = bikeloanService;
        }

        
        [HttpPost]

        public IActionResult GetBikeLoanDetails(BikeLoanRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var loanDetails =  _bikeloanService.GetBikeLoanDetails(request);
            return Ok(loanDetails);

            
        }
    }
}



