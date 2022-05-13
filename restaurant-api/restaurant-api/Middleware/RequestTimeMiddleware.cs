using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace restaurant_api.Middleware
{
    public class RequestTimeMiddleware : IMiddleware
    {
        private readonly ILogger<RequestTimeMiddleware> _logger;

        public RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Stopwatch stopwatch = new Stopwatch();
            
            stopwatch.Start();           
            await next.Invoke(context);
            stopwatch.Stop();

            if(stopwatch.ElapsedMilliseconds / 1000 > 4)
            {
                var message = $"Request: {context.Request.Method} at {context.Request.Path} took {stopwatch.ElapsedMilliseconds} ms";
                _logger.LogInformation(message);
            }
        }
    }
}
