namespace BankAcountEstatementApp.Models.DTOs
{
    public class StatementResponseDto
    {
        public int StatementId { get; set; }

        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
    }
}
