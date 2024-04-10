namespace PractiseServiceApp.Interfaces
{
    public interface IManager
    {
        public Guid Generateguid();

        public List<string> GetManagerlist();
    }
}
