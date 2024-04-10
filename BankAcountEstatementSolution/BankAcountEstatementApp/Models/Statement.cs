using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;
using Microsoft.EntityFrameworkCore;

namespace BankAcountEstatementApp.Models
{
    public class Statement
    {
        [Key]
        public int StatementId { get; set; }
        public int AccountNumber { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }

        [ForeignKey("AccountNumber")]
        public Account Account { get; set; }




    }
}
