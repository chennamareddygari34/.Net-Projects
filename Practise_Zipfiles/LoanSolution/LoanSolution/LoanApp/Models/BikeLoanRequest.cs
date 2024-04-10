using System.ComponentModel.DataAnnotations;

namespace LoanApp.Models
{
    public class BikeLoanRequest
    {
        [Display(Name = "BikeName")]
        [Required(ErrorMessage = "Please can be Provide the BikeName ")]
        [StringLength(100)]
        public string BikeName { get; set; }
        
        [Display(Name = "BikePrice")]
        [Required(ErrorMessage ="Please can be Provide the BikePrice ")]
        [Range(1000, 500000)]
        public int BikePrice { get; set; }
    }
}
