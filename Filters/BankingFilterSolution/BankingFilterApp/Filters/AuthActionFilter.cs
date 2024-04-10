using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BankingWebApi.Services
{
    public class AuthActionFilter : IAsyncActionFilter
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public async Task OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"This Filter Executed on: OnActionExecuted");
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine($"This Filter Executed on: OnActionExecution");

            var resultContext = await next(); 
        }
    }
}
