namespace CompanyWebApiApp.Services.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(string username);
    }
}
