using BankAcountEstatementApp.Interfaces;
using BankAcountEstatementApp.Models;
using BankAcountEstatementApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankAcountEstatementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly CurrencyService _currencyService;

        public CurrencyController(CurrencyService currencyService)
        {
            _currencyService = currencyService;
        }
        [HttpGet]
        public IActionResult GetAllCurrencies()
        {
            var currencies = _currencyService.GetAllCurrency();
            return Ok(currencies);
        }

        

    }
}





