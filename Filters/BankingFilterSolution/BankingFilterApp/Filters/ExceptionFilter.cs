using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace BankingWebApi.Services
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError($"Exception: {context.Exception.Message}");
            context.Result = new StatusCodeResult(500);
        }
    }
}
