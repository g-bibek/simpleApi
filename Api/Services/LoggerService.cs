using System;
using Microsoft.AspNetCore.Http;

namespace Api.Services
{
    interface ILoggerService
    {
        void LogCurrentRequest(HttpContext context, Exception exception);
    }
    public class LoggerService : ILoggerService
    {
        public void LogCurrentRequest(HttpContext context, Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}
