using System;
using Api.Models;

namespace Api.Services
{
    public interface IDateTimeService
    {
        /// <summary>
        /// Gets current UTC date time in "year-month-day hour:minutes:seconds" format
        /// </summary>
        /// <returns>Current UTC date time</returns>
        SimpleDateTime GetCurrentDateTime();
    }
    public class DateTimeService : IDateTimeService
    {
        public SimpleDateTime GetCurrentDateTime()
        {
            return new SimpleDateTime
            {
                CurrentDateTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
            };
        }
    }
}
