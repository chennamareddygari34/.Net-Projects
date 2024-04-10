
using BankAcountEstatementApp.Models;

namespace BankAcountEstatementApp.Interfaces
{
    public interface ITransactionService
    {
       List <Transaction> GetTransactionforAccountNumber(int accountNumber);

        Transaction GetTransactionById(int id);
        Transaction CreateTransaction(Transaction transaction);


    }
}
