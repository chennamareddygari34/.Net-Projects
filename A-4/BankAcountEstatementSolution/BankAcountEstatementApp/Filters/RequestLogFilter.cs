using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace BankingWebApi.Services
{
    public class RequestLogFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"This is RequestLogFilter Executed on: OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"This RequestLogFilter Executed on: OnActionExecuting");
        }


    }
}

