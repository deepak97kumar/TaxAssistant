using System;
using static TaxAssistant.UnitTest.Helpers.TaxData;
using static TaxAssistant.UnitTest.Helpers.Constants;
using TaxAssistant.Calculator.Interfaces;
using TaxAssistant.Calculator;
using System.Globalization;

namespace TaxAssistant.UnitTest.Calculator
{
    [TestFixture]
    public class ScheduledTaxTest
    {
        private readonly IScheduledTax _scheduledTax;

        public ScheduledTaxTest()
        {
            _scheduledTax = new ScheduledTax();
        }

        [Test]
        public void GetSchedule_Test_WhenDailyTaxAvailable()
        {
            var availableTest = AvailableTaxes();
            var expection = availableTest.Where(a => a.TaxType == Daily).First();
            var date = DateTime.ParseExact("2022-06-12", "yyyy-mm-dd", CultureInfo.InvariantCulture);
            var result = _scheduledTax.GetSchedule(availableTest, date);

            Assert.That(expection.TaxFactor, Is.EqualTo(result.TaxFactor));
        }
    }
}

