using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace BankAcountEstatementApp
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class HeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public HeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
           // httpContext.Response.Headers.Append("X-Frame-Options","SAMEORIGIN");

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
   // public static class HeaderMiddlewareExtensions
    //{
     //   public static IApplicationBuilder UseHeaderMiddleware(this IApplicationBuilder builder)
     //   {
         //   return builder.UseMiddleware<HeaderMiddleware>();
        //}
   // }
}
