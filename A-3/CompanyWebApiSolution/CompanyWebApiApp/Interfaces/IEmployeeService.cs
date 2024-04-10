using CompanyApplication.Models;

namespace CompanyWebApiApp.Interfaces
{
    public interface IEmployeeService
    {
        public Employee GetEmployeeByEmployeeId(int employeeid);
        public List<Employee> GetAllEmployee();
        public Employee AddNewEmployee(Employee employee);
        public Employee UpdateEmployee(Employee employee);
        public Employee DeleteEmployee(int employeeid);
    }
}
