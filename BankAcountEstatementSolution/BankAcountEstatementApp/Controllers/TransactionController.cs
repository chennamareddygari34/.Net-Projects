using BankAcountEstatementApp.Interfaces;
using BankAcountEstatementApp.Models;
using BankAcountEstatementApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankAcountEstatementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        private readonly ITransactionService _transactionService;
        private readonly ITransactionService? transactionService;

        public TransactionController(ITransactionService TransactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("statements/{accountNumber}")]

            public ActionResult<List<Transaction>> GetTransactionforAccountNumber(int accountNumber)
            {
                var transactions = _transactionService.GetTransactionforAccountNumber(accountNumber);

                if (transactions == null)
                {
                    return NotFound();
                }

                return transactions;
            }
        [HttpPost]
        public ActionResult CreateTransaction(Transaction transaction)
        {
            var CreatedTransaction = _transactionService.CreateTransaction(transaction);
            return Ok();

        }

    }
}
