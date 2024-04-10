using BankingFilterApp.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace BankingWebApi.Services
{
    public class BankingResultFilter : IAsyncResultFilter
    {
        private readonly ILogger<BankController> _logger;

        public BankingResultFilter(ILogger<BankController> logger)
        {
            _logger = logger;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            _logger.LogInformation("Executing BankingResultFilter...");
            var resultContext = await next();
            _logger.LogInformation("BankingResultFilter executed.");
        }
    
        

        public void OnResultExecuted(ResultExecutedContext context)
        {
            // Log the result if needed
            _logger.LogInformation($"Result: {context.Result}");
        }
    }
}

