using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace BankingWebApi.Interfaces
{
    public interface IResultFilter
    {
        void OnResultExecution(ResultExecutingContext context);
    }
}
