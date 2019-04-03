using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Api.Middlewares
{
    /// <summary>
    /// Authentication middleware to check for a valid auth token 
    /// </summary>
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext context, IServiceProvider serviceProvider)
        {
            context.Request.Headers.TryGetValue("Authorization", out var authToken);
            if (string.IsNullOrEmpty(authToken))
            {
                //context. = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            }

            await _next.Invoke(context);

        }
    }
}
