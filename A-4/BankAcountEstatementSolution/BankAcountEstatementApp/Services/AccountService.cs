using System.Security.Principal;
using BankAcountEstatementApp.Exceptions;
using BankAcountEstatementApp.Interfaces;
using BankAcountEstatementApp.Models;
using BankAcountEstatementApp.Models.DTOs;

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
            if (account != null)
            {
                return _repository.Add(account);
            }
            else
            {
                throw new InvalidUserEntryFilter();
            }
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
                throw new InvalidUserEntryFilter();
            }
        }

        

    

        public List<Account> GetAllAccounts()
        {
            return _repository.GetAll();
        }

        

        public Account UpdateAccount(int accountNumber, AccountDTO accountDto)
        {
            var Account = _repository.Get(accountNumber);
            if (Account != null)
            {
                Account.AccountHolderName = Account.AccountHolderName;
                Account.Email = Account.Email;
                return _repository.Update(Account);
            }
            return null;
        }
    }
}
