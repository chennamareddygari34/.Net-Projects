using CompanyApplication.Models;
using CompanyWebApiApp.Models.DTOs;

namespace CompanyWebApiApp.Services.Interfaces
{
    public interface IEmployeeService
    {
        public Employee GetEmployeeByEmployeeId(int employeeId);
        public List<Employee> GetAllEmployee();
        public CreateEmployeeDto AddNewEmployee(CreateEmployeeDto employeeDto);
        public Employee UpdateEmployee(Employee employee);
        public Employee DeleteEmployee(int employeeId);
    }
}
