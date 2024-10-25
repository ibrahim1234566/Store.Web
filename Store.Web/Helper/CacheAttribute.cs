using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Store.Service.Services.CacheService;
using System.Text;

namespace Store.Web.Helper
{
    public class CacheAttribute : Attribute, IAsyncActionFilter
    {
        private int _timeToLiveInSeconds;

        public CacheAttribute(int TimeToLiveInSeconds)
        {
            _timeToLiveInSeconds = TimeToLiveInSeconds;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var _cacheService = context.HttpContext.RequestServices.GetRequiredService<ICacheService>();
            var CacheKey = GenerateCacheKeyFromRequest(context.HttpContext.Request);
            var CacheResponse = await _cacheService.GetCacheResponseAsync(CacheKey);
            if (!string.IsNullOrEmpty(CacheResponse))
            {
                var contentResult = new ContentResult
                {
                    Content = CacheResponse,
                    ContentType = "application/json",
                    StatusCode = 200

                };
                context.Result = contentResult;
                return;
            }

            var executedContext = await next();
                if (executedContext.Result is OkObjectResult response) 
                {
                    await _cacheService.SetCacheResponseAsync(CacheKey, response.Value,TimeSpan.FromSeconds(_timeToLiveInSeconds));      
                }

            

        }
        private string GenerateCacheKeyFromRequest(HttpRequest request) 
        { 
           StringBuilder cacheKey = new StringBuilder();
            cacheKey.Append($"{request.Path}");
            foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
            {
                cacheKey.Append($"{key}-{value}");


            }
            return cacheKey.ToString();


        }
    }
}
