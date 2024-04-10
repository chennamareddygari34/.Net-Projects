using CompanyApplication.Interfaces.CompanyApplication.Interfaces;
using CompanyApplication.Models;
using CompanyWebApiApp.Interfaces;
using CompanyWebApiApp.Utilities;

namespace CompanyWebApiApp.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<int, Department> _repository;

        public DepartmentService(IRepository<int, Department> repository) 

        {
            _repository = repository;

        }
        public Department AddNewDepartment(Department department)
        {
            return _repository.Add(department);
        }

        public Department DeleteDepartment(int departmentnumber)
        {
            return _repository.Delete(departmentnumber);
        }

        public List<Department> GetAllDepartment()
        {
            return (List<Department>)_repository.GetAll();
        }

        public Department GetDepartmentByDepartmentNumber(int departmentnumber)
        {
            if (departmentnumber != null)
            {
                return _repository.Get(departmentnumber);
            }
            else
            {
                throw new InvalidUserEntry();
            }
        }

        public Department UpdateDepartment(Department department)
        {
            var myDepartment = _repository.Get(department.DepartmentNumber);
            if (myDepartment != null)
            {
                myDepartment.DepartmentName = department.DepartmentName;
                return _repository.Update(myDepartment);
            }
            else
            {
                throw new InvalidUserEntry();
            }
        }
    }
}
