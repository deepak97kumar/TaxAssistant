using System;
using System.Globalization;
using TaxAssistant.Repository.Models;
using static TaxAssistant.Calculator.Helpers.Constants;

namespace TaxAssistant.UnitTest.Helpers
{
    public static class TaxData
    {
        public static IEnumerable<Tax> AvailableTaxes()
        {
            return new List<Tax>
            {
                new Tax
                {
                    Id = Guid.NewGuid(),
                    MunicipalityName = "Test1",
                    TaxFactor=0.2f,
                    TaxType = Yearly,
                    ValidFrom = DateTime.ParseExact("2022-01-01","yyyy-mm-dd", CultureInfo.InvariantCulture),
                    ValidUntil = DateTime.ParseExact("2022-12-31", "yyyy-mm-dd", CultureInfo.InvariantCulture)
                },
                new Tax
                {
                    Id = Guid.NewGuid(),
                    MunicipalityName = "Test1",
                    TaxFactor=0.3f,
                    TaxType = Monthly,
                    ValidFrom = DateTime.ParseExact("2022-03-01","yyyy-mm-dd", CultureInfo.InvariantCulture),
                    ValidUntil = DateTime.ParseExact("2022-03-31", "yyyy-mm-dd", CultureInfo.InvariantCulture)
                },
                new Tax
                {
                    Id = Guid.NewGuid(),
                    MunicipalityName = "Test1",
                    TaxFactor=0.4f,
                    TaxType = Weekly,
                    ValidFrom = DateTime.ParseExact("2022-04-10","yyyy-mm-dd", CultureInfo.InvariantCulture),
                    ValidUntil = DateTime.ParseExact("2022-04-16", "yyyy-mm-dd", CultureInfo.InvariantCulture)
                },
                new Tax
                {
                    Id = Guid.NewGuid(),
                    MunicipalityName = "Test1",
                    TaxFactor=0.5f,
                    TaxType = Daily,
                    ValidFrom = DateTime.ParseExact("2022-06-12","yyyy-mm-dd", CultureInfo.InvariantCulture),
                    ValidUntil = DateTime.ParseExact("2022-06-12", "yyyy-mm-dd", CultureInfo.InvariantCulture)
                }
            };
        }
    }
}

