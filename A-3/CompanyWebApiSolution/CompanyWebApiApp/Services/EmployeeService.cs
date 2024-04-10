using System.Security.Principal;
using CompanyApplication.Interfaces.CompanyApplication.Interfaces;
using CompanyApplication.Models;
using CompanyWebApiApp.Interfaces;
using CompanyWebApiApp.Utilities;

namespace CompanyWebApiApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<int, Employee> _repository;

        public EmployeeService(IRepository<int, Employee> repository)
        {
            _repository = repository;
        }
        public Employee AddNewEmployee(Employee employee)
        {
            return _repository.Add(employee);
        }

        public Employee DeleteEmployee(int employeeid)
        {
            return _repository.Delete(employeeid);
        }

        public List<Employee> GetAllEmployee()
        {
            return (List<Employee>)_repository.GetAll();

        }

        public Employee GetEmployeeByEmployeeId(int employeeid)
        {
            if (employeeid != null)
            {
                return _repository.Get(employeeid);
            }
            else
            {
                throw new InvalidUserEntry();
            }

        }

        public Employee UpdateEmployee(Employee employee)
        {
            var myEmployee = _repository.Get(employee.EmployeeId);
            if (myEmployee != null)
            {
                myEmployee.EmployeeSalary = employee.EmployeeSalary;
                return _repository.Update(myEmployee);
            }
            else
            {
                throw new InvalidUserEntry();
            }
        }
    }
}
