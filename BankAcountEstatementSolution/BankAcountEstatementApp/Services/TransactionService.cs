using BankAcountEstatementApp.Interfaces;
using BankAcountEstatementApp.Models;
using BankAcountEstatementApp.Utilities;

namespace BankAcountEstatementApp.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IRepository<int, Transaction> _repository;
        private readonly object _context;
        private Account? accountNumber;

        public TransactionService(IRepository<int, Transaction> repository)
        { 

        }

        public Transaction GetTransactionById(int id)
        {
            throw new NotImplementedException();
        }
        public List<Transaction> GetTransaction()
        {
            return _repository.GetAll();


        }

        public Transaction CreateTransaction(Transaction Transaction)
        {
            return _repository.Add(Transaction);
        }




        public List<Transaction> GetTransactionforAccountNumber(int accountNumber)
        {
            var list = GetTransaction();
            var reslist = list.Where(pro => pro.AccountNumber == accountNumber).ToList();
            if (reslist.Count() > 0)
            {
                return reslist;
            }
            else
            {
                throw new InvalidUserEntry();
            }
        }

        public List<Transaction> GetTransactionforAccountNumber()
        {
            throw new NotImplementedException();
        }
    }
}
