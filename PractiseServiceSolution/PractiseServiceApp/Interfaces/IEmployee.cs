namespace PractiseServiceApp.Interfaces
{
    public interface IEmployee
    {
        public Guid Generateguid();
        public List<string> GetEmployeeslist();
    }
}
