namespace BankAcountEstatementApp.Models.DTOs
{
    public class AccountDTO
    {
        public string AccountNumber { get; set; }
        public string Email { get; set; }
        public string AccountHolderName { get; set; }
        public decimal CurrentBalance { get; set; }
        public DateTime AccountCreationDate { get; set; }
    }
}
