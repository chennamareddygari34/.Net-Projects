using CompanyApplication.Interfaces.CompanyApplication.Interfaces;
using CompanyApplication.Models;
using CompanyWebApiApp.Contexts;
using Microsoft.EntityFrameworkCore;


namespace CompanyApplication.Repositories
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        private readonly CompanyContext _context;

        public EmployeeRepository(CompanyContext context)
        {
            _context = context;
        }
        public Employee Add(Employee entity)
        {
            _context.employees.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Employee Delete(int key)
        {
            var employee = _context.employees.SingleOrDefault(x => x.EmployeeId == key);
            if (employee != null)
            {
                _context.employees.Remove(employee);
                _context.SaveChanges();
                return employee;
            }
            return null;
        }

        public Employee Get(int key)
        {
            var employee = _context.employees.FirstOrDefault(e => e.EmployeeId == key);
            if(employee != null)
            {
                return employee;
            }
            return null;
        }
            

        public ICollection<Employee> GetAll()
        {
            return _context.employees.ToList();
        }

        public Employee Update(Employee entity)
        {
            _context.Entry<Employee>(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
    }
}
