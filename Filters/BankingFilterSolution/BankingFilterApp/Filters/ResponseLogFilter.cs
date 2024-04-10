using BankingFilterApp.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace BankingWebApi.Services
{
    public class ResponseLogFilter : IAsyncActionFilter
    {
        private readonly ILogger<BankController> _logger;

        public ResponseLogFilter(ILogger<BankController> logger)
        {
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();
            _logger.LogInformation("Response sent at {DateTime}", DateTime.Now);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"Response: {context.HttpContext.Response.StatusCode}");
        }
    }
}
