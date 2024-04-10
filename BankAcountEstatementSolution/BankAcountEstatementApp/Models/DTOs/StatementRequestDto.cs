namespace BankAcountEstatementApp.Models.DTOs
{
    public class StatementRequestDto
    {
        

        public int AccountNumber { get; set; }
        public int Email { get; set; }
        public List<AccountsStatements> AccountStatements { get; set; }


    }
}
