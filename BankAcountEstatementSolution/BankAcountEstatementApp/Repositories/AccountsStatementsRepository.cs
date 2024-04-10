using BankAcountEstatementApp.Contexts;
using BankAcountEstatementApp.Interfaces;
using BankAcountEstatementApp.Models;

namespace BankAcountEstatementApp.Repositories
{
    public class AccountsStatementsRepository : IRepository<int, AccountsStatements>
    {
        private readonly EStatementContext _context;

        public AccountsStatementsRepository(EStatementContext context)
        {
            _context = context;
        }

        public AccountsStatements Add(AccountsStatements item)
        {
            throw new NotImplementedException();
        }

        public AccountsStatements Delete(int key)
        {
            throw new NotImplementedException();
        }

        public AccountsStatements Get(int key)
        {
            throw new NotImplementedException();
        }

        public Account GetAccountByNumber(int accountNumber)
        {
            throw new NotImplementedException();
        }

        public List<AccountsStatements> GetAll()
        {
            throw new NotImplementedException();
        }

        public AccountsStatements Update(AccountsStatements item)
        {
            throw new NotImplementedException();
        }
    }
}
