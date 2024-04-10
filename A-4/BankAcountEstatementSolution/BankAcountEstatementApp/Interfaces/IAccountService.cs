using BankAcountEstatementApp.Models;
using BankAcountEstatementApp.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BankAcountEstatementApp.Interfaces
{
    public interface IAccountService
    {
        List<Account> GetAllAccounts();
        Account CreateAccount(Account account);
        Account GetAccountByNumber(int accountNumber);
        Account UpdateAccount(int accountNumber, AccountDTO accountDto);
        Account DeleteAccount(int accountNumber);
    }
}
