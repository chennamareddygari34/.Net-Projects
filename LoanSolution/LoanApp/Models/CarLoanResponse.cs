using System.ComponentModel.DataAnnotations;

namespace LoanApp.Models
{
    public class CarLoanResponse
    {
        [Display(Name = "ApplicableLoanAmount")]
        [Required(ErrorMessage = "Please can be Provide the ApplicableLoanAmount ")]
        [Range(1000, 100000)]
        public int ApplicableLoanAmount { get; set; }

        [Display(Name = "InterestRate")]
        [Required(ErrorMessage = "Please can be Provide the InterestRate ")]
        [Range(0, 999.99)]
        public decimal InterestRate { get; set; }

        [Display(Name = "TenureInYears")]
        [Required(ErrorMessage = "Please can be Provide the TenureInYears ")]
        [Range(1, 10)]
        public int TenureInYears { get; set; }
    }
}
