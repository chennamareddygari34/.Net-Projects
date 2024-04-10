
using LoanApp.Interfaces;
using LoanApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoanApp.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    


    public class BusLoanController : ControllerBase
    {
        private readonly IBusLoanService _busloanService;
        public BusLoanController(IBusLoanService busloanService)
        {
            _busloanService = busloanService;
        }
        [HttpPost]
        public IActionResult GetLoanDetails(BusLoanRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var version = Request.Headers[CustomHttpHeaders.ApiVersion];

            

            var loanDetails = _busloanService.GetBusLoanDetails(request);
            return Ok(loanDetails);

        }
    }
}
