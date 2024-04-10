using BankAcountEstatementApp.Interfaces;
using BankAcountEstatementApp.Models.DTOs;
using BankAcountEstatementApp.Models;
using BankAcountEstatementApp.Repositories;
using System.Security.Principal;
using BankAcountEstatementApp.Utilities;
using Microsoft.AspNetCore.Mvc;

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

        public ActionResult<List<Statement>> GetStatementsForAccount(int accountNumber)
        {
             return new List<Statement>();
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
