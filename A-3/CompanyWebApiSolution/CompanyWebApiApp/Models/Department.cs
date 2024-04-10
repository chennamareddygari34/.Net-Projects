using System.ComponentModel.DataAnnotations;

namespace CompanyApplication.Models
{
    public class Department
    {
        [Display(Name = "DepartmentNumber")]
        [Required(ErrorMessage = "Please can be Provide the DepartmentNumber ")]
        [Range(1, 2000)]
        [Key]
        public int DepartmentNumber { get; set; }

        [Display(Name = "DepartmentName")]
        [Required(ErrorMessage = "Please can be Provide the DepartmentName ")]
        [StringLength(100)]
        public string DepartmentName { get; set; }

    }
}
