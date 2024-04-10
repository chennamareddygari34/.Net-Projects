using System;
using System.Diagnostics.Eventing.Reader;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BankingWebApi.Services
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (user.Identity.IsAuthenticated)
            {

                Console.WriteLine($"This AuthorizationFilter Executed on: OnActionExecuting");

                Console.WriteLine($"This AuthorizationFilter Executed on: OnActionExecuted");
            }


        }

        
    }
}
