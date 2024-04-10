using System.ComponentModel.DataAnnotations.Schema;

namespace BankAcountEstatementApp.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; } // Deposit or Withdrawal
        public int AccountNumber { get; set; }
        [ForeignKey("AccountNumber")]
        public Account? Account { get; set; }


    }
}
