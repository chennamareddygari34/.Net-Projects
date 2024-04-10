using BankingFilterApp.Models;
using BankingWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingFilterApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly List<BankAccount> _bankAccounts = new();
        private readonly ILogger<BankController> _logger;

        public BankController(ILogger<BankController> logger)
        {
            _logger = logger;
        }

        [HttpGet("accounts")]
        [ServiceFilter(typeof(RequestLogFilter))]
        [ServiceFilter(typeof(BankingResultFilter))]
        public IActionResult GetAccounts()
        {
            return Ok(_bankAccounts);
        }

        [HttpGet("accounts/{id}")]
        [ServiceFilter(typeof(RequestLogFilter))]
        [ServiceFilter(typeof(BankingResultFilter))]
        public IActionResult GetAccountById(int id)
        {
            var account = _bankAccounts.Find(a => a.Id == id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        [HttpPost("accounts")]
        [ServiceFilter(typeof(RequestLogFilter))]
        [ServiceFilter(typeof(BankingResultFilter))]
        public IActionResult CreateAccount([FromBody] BankAccount account)
        {
            account.Id = _bankAccounts.Count + 1; // Assign a new ID
            _bankAccounts.Add(account);
            return CreatedAtAction(nameof(GetAccountById), new { id = account.Id }, account);
        }

        [HttpPut("accounts/{id}")]
        [ServiceFilter(typeof(RequestLogFilter))]
        [ServiceFilter(typeof(BankingResultFilter))]
        public IActionResult UpdateAccount(int id, [FromBody] BankAccount updatedAccount)
        {
            var existingAccount = _bankAccounts.Find(a => a.Id == id);
            if (existingAccount == null)
            {
                return NotFound();
            }
            existingAccount.Name = updatedAccount.Name;
            existingAccount.Balance = updatedAccount.Balance;
            return Ok(existingAccount);
        }

        [HttpDelete("accounts/{id}")]
        [ServiceFilter(typeof(RequestLogFilter))]
        [ServiceFilter(typeof(BankingResultFilter))]
        public IActionResult DeleteAccount(int id)
        {
            var account = _bankAccounts.Find(a => a.Id == id);
            if (account == null)
            {
                return NotFound();
            }
            _bankAccounts.Remove(account);
            return NoContent();
        }
    }

    
}