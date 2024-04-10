using BankAcountEstatementApp.Interfaces;
using BankAcountEstatementApp.Models;
using BankAcountEstatementApp.Models.DTOs;
using BankAcountEstatementApp.Repositories;
using BankAcountEstatementApp.Utilities;


namespace BankAcountEstatementApp.Services
{
    public class StatementService : IStatementService

    {
        private readonly IRepository<int, Statement> _repository;
        private readonly object _context;
        private Account? accountNumber;
        private readonly ICurrencyService _currencyService;
        private readonly object _statementRepository;
        private readonly object _accountRepository;

        public StatementService(IRepository<int, Statement> repository, ICurrencyService currencyService)
        {
            _repository = repository;
            _currencyService = currencyService;
        }

        public Statement CreateStatement(Statement Statement)
        {
            return _repository.Add(Statement);
        }



        public List<Statement> GetStatementsForAccount(int accountNumber)
        {

            var list = GetStatement();
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


        public List<Statement> GetStatement()
        {
            return _repository.GetAll();


        }

        public StatementResponseDto AddNewStatement(Statement statements)
        {
            if (statements != null)
            {
                var data = _repository.Add(statements);

                StatementResponseDto statementResponseDto = new StatementResponseDto();
                statementResponseDto.StatementId = data.StatementId;
                statementResponseDto.PeriodStart = data.PeriodStart;
                statementResponseDto.PeriodEnd = data.PeriodEnd;
                return statementResponseDto;

            }
            else
            {
                throw new InvalidUserEntry();
            }
        }

        public StatementRequestDto GetListOfStatementByStatementId(int statementId)
        {
            throw new NotImplementedException();
        }

        
    }
}


