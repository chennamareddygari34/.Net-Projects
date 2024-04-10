using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAcountEstatementApp.Models
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }
        public string CurrencyName { get; set; }
        public string Symbol { get; set; }
        public int AccountNumber { get; set; }

        
    }
}
