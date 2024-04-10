using CompanyApplication.Models;

namespace CompanyWebApiApp.Interfaces
{
    public interface IDepartmentService
    {
        public Department GetDepartmentByDepartmentNumber(int departmentnumber);
        public List<Department> GetAllDepartment();
        public Department AddNewDepartment(Department department);
        public Department UpdateDepartment(Department department);
        public Department DeleteDepartment(int departmentnumber);


    }
}
