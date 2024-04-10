using BankAcountEstatementApp.Interfaces;
using BankAcountEstatementApp.Models.DTOs;
using BankAcountEstatementApp.Models;
using BankAcountEstatementApp.Contexts;

namespace BankAcountEstatementApp.Repositories
{
    public class StatementRepository : IRepository<int, Statement>
    {
        private readonly EStatementContext _context;

        public StatementRepository(EStatementContext context)
        {
            _context = context;
        }
        

        public Statement Add(Statement item)
        {
            _context.statements.Add(item);
            _context.SaveChanges();
            return item;
        }

            public Statement Delete(int key)
        {
            var statements = Get(key);
            if (statements != null)
            {
                _context.statements.Remove(statements);
                _context.SaveChanges();
                return statements;
            }
            return null;
        }

        

        public Statement Get(int key)
        {
            var statements = _context.statements.FirstOrDefault(x => x.AccountNumber == key);
            return statements;
        }

        

        public List<Statement> GetAll()
        {
            return _context.statements.ToList();
        }

        public Statement Update(Statement item)
        {
            _context.Entry<Statement>(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return item;
        }
    }
}