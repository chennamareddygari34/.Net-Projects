using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace BankingWebApi.Services
{
    public class ResponseLogFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"This ResponseLogFilter Executed on: OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"This ResponseLogFilter Executed on: OnActionExecuting");
        }
    }
}
