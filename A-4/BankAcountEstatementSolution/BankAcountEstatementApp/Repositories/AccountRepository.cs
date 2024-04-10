using BankAcountEstatementApp.Interfaces;
using BankAcountEstatementApp.Models.DTOs;
using BankAcountEstatementApp.Models;
using BankAcountEstatementApp.Contexts;

namespace BankAcountEstatementApp.Repositories
{
    public class AccountRepository : IRepository<int, Account>
    {
        private readonly FilterContext _context;

        public AccountRepository(FilterContext context)
        {
            _context = context;
        }

        public Account Add(Account item)
        {
            _context.accounts.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Account Delete(int key)
        {
            var accounts = Get(key);
            if (accounts != null)
            {
                _context.accounts.Remove(accounts);
                _context.SaveChanges();
                return accounts;
            }
            return null;
        }

        public Account Get(int key)
        {
            var accounts = _context.accounts.FirstOrDefault(x => x.AccountNumber == key);
            return accounts;
        }

        public Account GetAccountByNumber(int accountNumber)
        {
            throw new NotImplementedException();
        }

        public List<Account> GetAll()
        {
            return _context.accounts.ToList();
        }

        public Account Update(Account item)
        {
            _context.Entry<Account>(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return item;
        }

        
    }
}