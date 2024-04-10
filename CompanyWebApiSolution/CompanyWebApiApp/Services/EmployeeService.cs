using AutoMapper;
using CompanyApplication.Interfaces.CompanyApplication.Interfaces;
using CompanyApplication.Models;
using CompanyWebApiApp.Models.DTOs;
using CompanyWebApiApp.Services.Interfaces;
using CompanyWebApiApp.Utilities;

namespace CompanyWebApiApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<int, Employee> _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IRepository<int, Employee> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public CreateEmployeeDto AddNewEmployee(CreateEmployeeDto employeeDto)
        {
            var employeeModel = _mapper.Map<Employee>(employeeDto);
            employeeModel = _repository.Add(employeeModel);
            var createEmpDto = _mapper.Map<CreateEmployeeDto>(employeeModel);
            return createEmpDto;
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
            var updatedEmp = _repository.Update(employee);
            if (updatedEmp == null)
            {
                return null;
            }
            return updatedEmp;
        }
    }
}
