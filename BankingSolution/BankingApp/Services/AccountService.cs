using BankAcountEstatementApp.Interfaces;
using BankAcountEstatementApp.Models;
using BankAcountEstatementApp.Utilities;

namespace BankAcountEstatementApp.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<int, Account> _repository;

        public AccountService(IRepository<int, Account> repository)
        {
            _repository = repository;
        }

        public Account CreateAccount(Account account)
        {
            return _repository.Add(account);
        }

        public Account DeleteAccount(int accountNumber)
        {
            return _repository.Delete(accountNumber);
        }

        public Account GetAccountByNumber(int accountNumber)
        {

            if (accountNumber != null)
            {
                return _repository.Get(accountNumber);
            }
            else
            {
                throw new InvalidUserEntry();
            }

        }

        public List<Account> GetAllAccounts()
        {
            return _repository.GetAll();
        }

        public Account UpdateAccount(int accountNumber)
        {
            throw new NotImplementedException();
        }
    }
}
