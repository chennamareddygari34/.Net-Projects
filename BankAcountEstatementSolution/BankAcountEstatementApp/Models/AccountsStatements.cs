namespace BankAcountEstatementApp.Models
{
    public class AccountsStatements
    {
        public int StatementId { get; set; }
        public Statement? Statement { get; set; }

        public int AccountNumber { get; set; }
        public Account Account { get; set; }
    }
}
