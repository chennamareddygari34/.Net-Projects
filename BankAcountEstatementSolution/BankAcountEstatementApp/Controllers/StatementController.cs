using System.Security.Principal;
using BankAcountEstatementApp.Interfaces;
using BankAcountEstatementApp.Models;
using BankAcountEstatementApp.Models.DTOs;
using BankAcountEstatementApp.Services;
using BankAcountEstatementApp.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace BankAcountEstatementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatementController : ControllerBase
    {
        private readonly IStatementService _statementService;
        private readonly IAccountService _accountService;
        private readonly object _repository;

        public StatementController(IStatementService statementService)
        {
            _statementService = statementService;

        }


        [HttpGet]
        public IActionResult GetStatement()
        {
            var statements = _statementService.GetStatement();
            return Ok(statements);
        }
        [HttpPost]
        public ActionResult CreateStatement(Statement statement)
        {
            var createdStatement = _statementService.CreateStatement(statement);
            return Ok();

        }


        [HttpGet("statements/{accountNumber}")]

        public ActionResult<List<Statement>> GetStatementsForAccount(int accountNumber)
        {
            var statements = _statementService.GetStatementsForAccount(accountNumber);


            if (statements == null || statements.Count == 0)
            {

                return NotFound();
            }
            else
            {
                //var account = _statementService.GetAccountByNumber(accountNumber);

                //foreach (var statement in statements)
                //{
                //    statement.Account = account;
                //}
                return statements;
            }
        }
    }



}

        //[HttpPost]
        //public ActionResult AddNewStatement(StatementRequestDto statementRequest)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (statementRequest != null)
        //        {
        //            // Create a Statement object using the provided account number
        //            var statement = new Statement
        //            {
        //                AccountNumber = statementRequest.AccountNumber,

        //            };

        //        }
        //        else
        //        {
        //            throw new InvalidUserEntry();
        //        }
        //    }
        //    else
        //    {

        //        return Ok("");
        //    }
        //}
    



