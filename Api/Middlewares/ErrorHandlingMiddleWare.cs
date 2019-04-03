using System;
using System.Threading.Tasks;
using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Api.Middlewares
{
    /// <summary>
    /// Middleware to handle any unhandled exceptions in the application
    /// </summary>
    public class ErrorHandlingMiddleWare
    {
        private readonly IConfiguration _configuration;
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleWare(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Handles any unhandled exceptions in the application
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {

            var result = JsonConvert.SerializeObject(new
            {
                error = "There was an error processing your request",
                referenceId = $"{Guid.NewGuid().GetHashCode():X}"
            });

            //var logger = context.RequestServices.GetService<ILoggerService>();
            //logger.LogCurrentRequest(context, exception);
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}
