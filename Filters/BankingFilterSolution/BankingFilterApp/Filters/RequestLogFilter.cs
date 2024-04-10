using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace BankingWebApi.Services
{
    public class RequestLogFilter : IAsyncActionFilter
    {
        private readonly ILogger<RequestLogFilter> _logger;

        public RequestLogFilter(ILogger<RequestLogFilter> logger)
        {
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _logger.LogInformation($"Request: {context.HttpContext.Request.Path} {context.HttpContext.Request.Method}");
            await Task.CompletedTask; 
        }

        public async Task OnActionExecutedAsync(ActionExecutedContext context)
        {
            
            await Task.CompletedTask; 
        }

        
    }
}
