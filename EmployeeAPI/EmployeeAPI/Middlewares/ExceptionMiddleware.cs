using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace EmployeeApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception caught by global middleware.");
                await HandleExceptionAsync(context, ex, _env);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex, IWebHostEnvironment env)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            object response = env.IsDevelopment()
                ? new
                {
                    statusCode = context.Response.StatusCode,
                    message = ex.Message,
                    stackTrace = ex.StackTrace
                }
                : new
                {
                    statusCode = context.Response.StatusCode,
                    message = "An unexpected error occurred."
                };

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response, options));
        }
    }
}