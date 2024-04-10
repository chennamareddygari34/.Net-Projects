using BankAcountEstatementApp.Contexts;
using BankAcountEstatementApp.Interfaces;
using BankAcountEstatementApp.Models;

namespace BankAcountEstatementApp.Repositories
{
    public class TransactionRepository : IRepository<int, Transaction>
    {
        private readonly EStatementContext _context;
        public TransactionRepository(EStatementContext context)
        {
            _context = context;

        }

        public Transaction Add(Transaction item)
        {
            _context.transactions.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Transaction Delete(int key)
        {
            var transaction = Get(key);
            if (transaction != null)
            {
                _context.transactions.Remove(transaction);
                _context.SaveChanges();
            }
            return null;
        }

        public Transaction Get(int key)
        {
            var transaction = _context.transactions.FirstOrDefault(u => u.TransactionId == key);
            return transaction;
        }

        public Account GetAccountByNumber(int accountNumber)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetAll()
        {
            return _context.transactions.ToList();
        }

        public Transaction Update(Transaction item)
        {
            _context.Entry<Transaction>(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return item;
        }
    }
}
