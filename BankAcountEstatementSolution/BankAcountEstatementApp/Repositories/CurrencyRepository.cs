using BankAcountEstatementApp.Contexts;
using BankAcountEstatementApp.Interfaces;
using BankAcountEstatementApp.Models;

namespace BankAcountEstatementApp.Repositories
{
    public class CurrencyRepository : IRepository<int, Currency>
    {
        private readonly EStatementContext _context;

        public CurrencyRepository(EStatementContext context)
        {
            _context = context;
        }

        public Currency Add(Currency currency)
        {
            _context.currency.Add(currency);
            _context.SaveChanges();
            return currency;
        }

        public Currency Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Currency Get(int key)
        {
            var currency = _context.currency.FirstOrDefault(x => x.Id == key);
            return currency;
        }

        public Account GetAccountByNumber(int accountNumber)
        {
            throw new NotImplementedException();
        }

        public List<Currency> GetAll()
        {
            return _context.currency.ToList();
        }

        public Currency Update(Currency item)
        {
            throw new NotImplementedException();
        }
    }
}
