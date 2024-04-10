using System.Globalization;
using BankAcountEstatementApp.Interfaces;
using BankAcountEstatementApp.Models;
using BankAcountEstatementApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BankAcountEstatementApp.Services
{
    public class CurrencyService : ICurrencyService
    {

        private readonly IServiceScopeFactory _serviceScopeFactory;

        public CurrencyService(IServiceScopeFactory serviceScopeFactory)
        { _serviceScopeFactory = serviceScopeFactory; }
        public List<Currency> GetAllCurrency()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var _repository = scope.ServiceProvider.GetService<IRepository<int, Currency>>();

                if (_repository != null)
                    return _repository.GetAll();
                else
                    return new List<Currency>();
            }
        }
    }
}
        

