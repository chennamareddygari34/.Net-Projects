using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace BankingWebApi.Interfaces
{
    public interface IResultFilter
    {
        Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next);
    }
}
