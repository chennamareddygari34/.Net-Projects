using Microsoft.AspNetCore.Mvc.Filters;

namespace BankingWebApi.Interfaces
{
    public interface IActionFilter
    {
        Task OnActionExecutingAsync(ActionExecutingContext context);
        Task OnActionExecutedAsync(ActionExecutedContext context);

    }
}
