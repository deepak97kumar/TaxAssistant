using System;
using Microsoft.EntityFrameworkCore;
using TaxAssistant.Repository;
using TaxAssistant.Repository.Repositories;
using TaxAssistant.Repository.Models;
using static TaxAssistant.UnitTest.Helpers.Constants;

namespace TaxAssistant.UnitTest.Repositories
{
    [TestFixture]
    public class TaxRepositoryTest : TestBase
    {
        [Test]
        public void GetAll_Test()
        {
            // Arrange

            var taxes = new List<Tax>
                {
                    new Tax{Id = Guid.NewGuid()},
                    new Tax{Id = Guid.NewGuid()},
                    new Tax{Id = Guid.NewGuid()}
                };

            _context.AddRange(taxes);
            _context.SaveChanges();

            // Act

            var taxRepository = new TaxRepository(_context);
            var allTaxes = taxRepository.GetAll();

            //Assert
            Assert.That(allTaxes.Count(), Is.EqualTo(3));

            CleanUp(taxes);
        }

        [Test]
        public async Task CreateNewTax_Test()
        {
            // Arrange
            var firstDayOfYear = DateTime.ParseExact("2022-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            var lastDayOfYear = DateTime.ParseExact("2022-12-31", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            var tax = new Tax
            {
                Id = Guid.NewGuid(),
                MunicipalityName = "TestMunicipality",
                TaxFactor = (float?)0.2,
                TaxType = Yearly,
                ValidFrom = firstDayOfYear,
                ValidUntil = lastDayOfYear
            };

            var taxRepository = new TaxRepository(_context);

            // Act
            var _ = taxRepository.Create(tax);

            var result = await taxRepository.GetById(tax.Id);

            // Assert
            Assert.That(taxRepository.GetAll().Count(), Is.EqualTo(1));
            Assert.That(result.Id, Is.EqualTo(tax.Id));
            CleanUp(new List<Tax> { tax });
        }

        [Test]
        public async Task UpdateTax_Test()
        {
            // Arrange
            var firstDayOfYear = DateTime.ParseExact("2022-01-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            var lastDayOfYear = DateTime.ParseExact("2022-12-31", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            var tax = new Tax
            {
                Id = Guid.NewGuid(),
                MunicipalityName = "TestMunicipality",
                TaxFactor = (float?)0.2,
                TaxType = Yearly,
                ValidFrom = firstDayOfYear,
                ValidUntil = lastDayOfYear
            };

            var taxRepository = new TaxRepository(_context);
            var _ = taxRepository.Create(tax);

            // Act
            tax.TaxFactor = (float?)0.3;

            await taxRepository.Update(tax);
            var result = await taxRepository.GetById(tax.Id);

            // Assert
            Assert.That(taxRepository.GetAll().Count(), Is.EqualTo(1));
            Assert.That(result.TaxFactor, Is.EqualTo((float?)0.3));
            CleanUp(new List<Tax> { tax });
        }

        [Test]
        public async Task GetById_Test()
        {
            var id = Guid.NewGuid();
            // Arrange
            var tax = new Tax { Id = id };

            var taxRepository = new TaxRepository(_context);
            var _ = taxRepository.Create(tax);

            // Act
            var result = await taxRepository.GetById(tax.Id);

            // Assert
            Assert.That(taxRepository.GetAll().Count(), Is.EqualTo(1));
            Assert.That(result.Id, Is.EqualTo(tax.Id));
            CleanUp(new List<Tax> { tax });
        }

        private void CleanUp(List<Tax> taxes)
        {
            base.CleanUp<Tax>(taxes);
        }
    }
}

