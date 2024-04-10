using Microsoft.AspNetCore.Mvc.Filters;

namespace BankingWebApi.Interfaces
{
    public interface IExceptionFilter
    {
        void OnException(ExceptionContext context);
    }
}
