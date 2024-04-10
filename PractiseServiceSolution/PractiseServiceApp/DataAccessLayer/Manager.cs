using PractiseServiceApp.Interfaces;

namespace PractiseServiceApp.DataAccessLayer;
public class Manager : IManager
{
    Guid id;
    public Manager()
    {
        id = Guid.NewGuid();
    }

    public Guid Generateguid()
    {
        return id;
    }

    public List<string> GetManagerlist()
    {
        List<string> lstobj = new List<string>();
        lstobj.Add("John");
        lstobj.Add("Michael");
        lstobj.Add("Sara");
        return lstobj;
    }
}

