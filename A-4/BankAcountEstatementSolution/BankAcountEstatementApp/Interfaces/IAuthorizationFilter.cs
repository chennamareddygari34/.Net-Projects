using Microsoft.AspNetCore.Mvc.Filters;

namespace BankAcountEstatementApp.Interfaces
{
    public interface IAuthorizationFilter
    {
        void OnAuthorization(AuthorizationFilterContext context);

    }
}
