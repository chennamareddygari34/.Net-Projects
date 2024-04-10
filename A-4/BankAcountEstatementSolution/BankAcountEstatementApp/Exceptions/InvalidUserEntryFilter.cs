namespace BankAcountEstatementApp.Exceptions
{
    public class InvalidUserEntryFilter : Exception
    {
        string message = "";
        public InvalidUserEntryFilter()
        {
            message = "No Data or list found as of now please add";
        }
        public override string Message => message;
    }
}
