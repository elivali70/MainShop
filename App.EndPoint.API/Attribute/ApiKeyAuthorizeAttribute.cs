using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace App.EndPoint.API.Attribute
{
    public class ApiKeyAuthorizeAttribute : System.Attribute, IAsyncActionFilter
    {
        private const string APIKEYNAME = "ApiKey";
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if(!context.HttpContext.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            {
                context.Result= new ContentResult()
                {
                    StatusCode=401,
                        Content = "ApiKey Was Not Found"
                       
                };
                return;
            }
            var appSetting = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey=appSetting.GetSection(APIKEYNAME);
            if (!(apiKey.Value==extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "ApiKey is Not Valid"
                };
                return;
                
            }
            await next();
        }
    }
}
