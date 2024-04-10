using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace BankAcountEstatementApp.Models
{
    public class Account
    {
        [Key]
        public int AccountNumber { get; set; }
        public string Email { get; set; }
        public string AccountHolderName { get; set; }
        public decimal Balance { get; set; }
        public DateTime AccountCreationDate { get; set; }


    }
}
