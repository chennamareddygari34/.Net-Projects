namespace CompanyWebApiApp.Models.DTOs
{
    public class CreateEmployeeDto
    {
        public string EmployeeName { get; set; }
        public string DateOfBirth { get; set; }
        public string EmployeeEmail { get; set; }
        public int EmployeePhone { get; set; }
        public float EmployeeSalary { get; set; }
    }
}
