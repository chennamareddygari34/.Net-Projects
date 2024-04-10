using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace BankAcountEstatementApp.Exceptions
{
    public class NotFoundFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ArgumentNullException)
            {
                context.Result = new NotFoundResult();
                context.ExceptionHandled = true;
            }
        }
    }
}
