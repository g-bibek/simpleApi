using System;
using Api.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Api.Test
{
    [TestClass]
    public class DateTimeServiceTest
    {
        private readonly IDateTimeService _dateTimeService;

        public DateTimeServiceTest()
        {
            _dateTimeService = new DateTimeService();
        }

        [TestMethod]
        public void IsGetCurrentDateTimeNotNull_ExpectTrue()
        {
            var result = _dateTimeService.GetCurrentDateTime();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IsGetCurrentDateTimeCorrect_ExpectTrue()
        {
            var pastDateTime = Convert.ToDateTime(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
            var result = _dateTimeService.GetCurrentDateTime();
            var resultDate = Convert.ToDateTime(result.CurrentDateTime);
            var futureDateTime = Convert.ToDateTime(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
            Assert.IsTrue(pastDateTime <= resultDate && resultDate <= futureDateTime);
        }
    }
}
