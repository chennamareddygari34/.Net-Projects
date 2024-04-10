using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace BankAcountEstatementApp.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ArgumentException)
            {
                context.Result = new ObjectResult("Invalid account number.") { StatusCode = StatusCodes.Status400BadRequest };
                context.ExceptionHandled = true;
            }
            else
            {
                context.Result = new ObjectResult("An error occurred.") { StatusCode = StatusCodes.Status500InternalServerError };
                context.ExceptionHandled = true;
            }
        }
    }
}
