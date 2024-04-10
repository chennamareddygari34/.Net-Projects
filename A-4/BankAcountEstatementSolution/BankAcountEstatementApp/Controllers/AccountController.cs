using BankAcountEstatementApp.Interfaces;
using BankAcountEstatementApp.Models.DTOs;
using BankAcountEstatementApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using BankingWebApi.Services;
using BankAcountEstatementApp.Exceptions;
using BankAcountEstatementApp.Filters;

namespace BankAcountEstatementApp.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(AuthorizationFilter))]



    [EnableCors("MyCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
            private readonly IAccountService _accountService;

            public AccountController(IAccountService accountService)
            {
                _accountService = accountService;
            }
           
            [Authorize]
            [HttpGet]
            public IActionResult GetAllAccounts()
            {
                var accounts = _accountService.GetAllAccounts();
                return Ok(accounts);
            }

        [Authorize]
        [ServiceFilter(typeof(InvalidUserEntryFilter))]
        [HttpPost]

        public IActionResult CreateAccount(Account account)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    var createdAccount = _accountService.CreateAccount(account);
                    return CreatedAtAction(nameof(GetAccountByNumber), new { accountNumber = createdAccount.AccountNumber }, createdAccount);
                }
                catch (InvalidUserEntryFilter e)
                {
                    return BadRequest(e.Message);
                }
            }
            return BadRequest(ModelState.Keys);

        }


        [ServiceFilter(typeof(RequestLogFilter))]

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
            public IActionResult UpdateAccount(int accountNumber, AccountDTO accountDto)
            {
                var updatedAccount = _accountService.UpdateAccount(accountNumber, accountDto);
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
