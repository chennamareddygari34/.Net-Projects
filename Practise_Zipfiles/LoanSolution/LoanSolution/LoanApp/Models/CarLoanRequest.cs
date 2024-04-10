using System.ComponentModel.DataAnnotations;

namespace LoanApp.Models
{
    public class CarLoanRequest
    {
        [Display(Name = "CarName")]
        [Required(ErrorMessage = "Please can be Provide the CarName ")]
        [StringLength(100)]
        public string CarName { get; set; }

        [Display(Name = "CarPrice")]
        [Required(ErrorMessage = "Please can be Provide the CarPrice ")]
        [Range(1000, 1000000)]
        public int CarPrice { get; set; }
    }
}
