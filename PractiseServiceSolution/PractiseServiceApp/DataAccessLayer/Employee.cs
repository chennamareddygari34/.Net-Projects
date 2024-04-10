using PractiseServiceApp.Interfaces;

namespace PractiseServiceApp.DataAccessLayer
{
    public class Employee : IEmployee
    {
        Guid id;
        public Employee()
        {
            id = Guid.NewGuid();
        }

        public Guid Generateguid()
        {
            return id;
        }

        public List<string> GetEmployeeslist()
        {
            List<string> lstobj = new List<string>();
            lstobj.Add("Pavan");
            lstobj.Add("Babu");
            lstobj.Add("Jan");
            return lstobj;
        }
    }
}
