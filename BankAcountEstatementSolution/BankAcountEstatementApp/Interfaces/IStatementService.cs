using BankAcountEstatementApp.Models;
using BankAcountEstatementApp.Models.DTOs;

namespace BankAcountEstatementApp.Interfaces
{
    public interface IStatementService
    {
        Statement CreateStatement(Statement statement);
        List<Statement> GetStatementsForAccount(int accountNumber);
        List<Statement> GetStatement();

        public StatementResponseDto AddNewStatement(Statement statements);

        public StatementRequestDto GetListOfStatementByStatementId(int statementId);
    }
}

