using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace BankingWebApi.Services
{
    public class BankingResultFilter : Attribute,IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {

            Console.WriteLine($"This BankingResultFilter Executed on: OnActionExecuted");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine($"This BankingResultFilter Executed on: OnActionExecuting");
        }
    }
}

