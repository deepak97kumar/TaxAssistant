using System;
using System.Globalization;
using Moq;
using TaxAssistant.Repository.Repositories.Interface;
using TaxAssistant.Repository.Models;
using TaxAssistant.Calculator.Interfaces;
using TaxAssistant.Calculator;
using static TaxAssistant.Calculator.Helpers.Constants;
using static TaxAssistant.UnitTest.Helpers.TaxData;

namespace TaxAssistant.UnitTest.Calculator
{
    [TestFixture]
    public class TaxCalculatorTest
    {
        private Mock<ITaxRepository> _taxRepository;
        private Mock<IScheduledTax> _scheduledTax;
        private Mock<IDuplicateTaxValidator> _duplicateTaxValidator;
        private readonly ITaxCalculator _taxCalculator;

        public TaxCalculatorTest()
        {
            _taxRepository = new Mock<ITaxRepository>();
            _scheduledTax = new Mock<IScheduledTax>();
            _duplicateTaxValidator = new Mock<IDuplicateTaxValidator>();
            _taxCalculator = new TaxCalculator(_taxRepository.Object, _scheduledTax.Object, _duplicateTaxValidator.Object);
        }

        [TestCase(Yearly, "Test1", 0.2f)]
        [TestCase(Weekly, "Test1", 0.4f)]
        [TestCase(Monthly, "Test1", 0.3f)]
        [TestCase(Daily, "Test1", 0.5f)]
        [TestCase("some_mode", "Test1", null)]
        public async Task GetTax_Test(string mode, string municipalityName, float? expection)
        {
            var taxes = AvailableTaxes();
            _taxRepository.Setup(t => t.GetByMunicipality(municipalityName)).Returns(Task.FromResult(taxes));
            var dummyDate = DateTime.UtcNow;

            var tax = mode switch
            {
                Yearly => taxes.ElementAt(0),
                Monthly => taxes.ElementAt(1),
                Weekly => taxes.ElementAt(2),
                Daily => taxes.ElementAt(3),
                _ => null
            }; ;

            _scheduledTax.Setup(s => s.GetSchedule(taxes, dummyDate)).Returns(tax!);

            var result = await _taxCalculator.GetTax(municipalityName, dummyDate);

            Assert.That(result, Is.EqualTo(expection));
        }


    }
}

