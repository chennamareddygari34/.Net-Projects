using Microsoft.AspNetCore.Mvc;

namespace LoanApp
{
    internal class ApiVersionMetadata
    {
        private ApiVersion apiVersion;

        public ApiVersionMetadata(ApiVersion apiVersion)
        {
            this.apiVersion = apiVersion;
        }
    }
}