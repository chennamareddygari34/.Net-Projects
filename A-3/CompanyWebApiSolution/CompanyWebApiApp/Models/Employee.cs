﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyApplication.Models
{
    public class Employee
    {
        [Display(Name = "EmployeeId")]
        [Required(ErrorMessage = "Please can be Provide the EmployeeId ")]
        [Range(1, 2000)]
        [Key]
        public int EmployeeId { get; set; }
        
        [Display(Name = "EmployeeName")]
        [Required(ErrorMessage = "Please can be Provide the EmployeeName ")]
        [StringLength(100)]
        public string EmployeeName { get; set; }

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Please provide the Date of Birth")]
        public string DateOfBirth { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please provide the Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmployeeEmail { get; set; }



        [Display(Name = "EmployeePhone")]
        [Required(ErrorMessage = "Please can be Provide the EmployeePhone ")]
        public int EmployeePhone { get; set; }

        [Display(Name = "EmployeeSalary")]
        [Required(ErrorMessage = "Please can be Provide the EmployeeSalary ")]
        [Range(10000, 200000)]
        public float EmployeeSalary { get; set; }
       
        

    }
}
