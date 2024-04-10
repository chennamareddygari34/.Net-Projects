using BankAcountEstatementApp.Interfaces;
using BankAcountEstatementApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankAcountEstatementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
            private readonly IAccountService _accountService;

            public AccountController(IAccountService accountService)
            {
                _accountService = accountService;
            }

            [HttpGet]
            public IActionResult GetAllAccounts()
            {
                var accounts = _accountService.GetAllAccounts();
                return Ok(accounts);
            }
        
        [Authorize(Roles = "Manager")]
        [HttpPost]
            public IActionResult CreateAccount(Account account)
            {
                var createdAccount = _accountService.CreateAccount(account);
                return CreatedAtAction(nameof(GetAccountByNumber), new { accountNumber = createdAccount.AccountNumber }, createdAccount);
            }

            [HttpGet("{accountNumber}")]
            public IActionResult GetAccountByNumber(int accountNumber)
            {
                var account = _accountService.GetAccountByNumber(accountNumber);
                if (account == null)
                {
                    return NotFound();
                }
                return Ok(account);
            }

            [HttpPut("{accountNumber}")]
            public IActionResult UpdateAccount(int accountNumber)
            {
                var updatedAccount = _accountService.UpdateAccount(accountNumber);
                if (updatedAccount == null)
                {
                    return NotFound();
                }
                return Ok(updatedAccount);
            }

            [HttpDelete("{accountNumber}")]
            public IActionResult DeleteAccount(int accountNumber)
            {
                var deletedAccount = _accountService.DeleteAccount(accountNumber);
                if (deletedAccount == null)
                {
                    return NotFound();
                }
                return Ok(deletedAccount);
            }

           
        
    }
}
