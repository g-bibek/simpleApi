using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [Route("DateTime")]
    public class DateTimeController: BaseController
    {
        private readonly IDateTimeService _dateTimeService;

        public DateTimeController(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
        }

        /// <summary>
        /// Endpoint to get current UTC date time in "year-month-day hour:minutes:seconds" format
        /// </summary>
        /// <returns>Current UTC date time</returns>
        [HttpGet("now")]
        public ActionResult<SimpleDateTime> GetCurerntDateTime()
        {
            var currentDate = _dateTimeService.GetCurrentDateTime();
            return Ok(JsonConvert.SerializeObject(currentDate));
        }
    }
}
