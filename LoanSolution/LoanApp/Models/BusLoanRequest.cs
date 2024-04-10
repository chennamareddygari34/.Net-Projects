using System.ComponentModel.DataAnnotations;

namespace LoanApp.Models
{
    public class BusLoanRequest
    {
        [Display(Name = "BusName")]
        [Required(ErrorMessage = "Please can be Provide the BusName ")]
        [StringLength(100)]
        [Key]
        public string BusName { get; set; }

        [Display(Name = "BusPrice")]
        [Required(ErrorMessage = "Please can be Provide the BusPrice ")]
        [Range(1000, 2000000)]
        public int BusPrice { get; set; }
    }
}
