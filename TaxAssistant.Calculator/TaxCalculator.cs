using Microsoft.EntityFrameworkCore;
using TaxAssistant.Calculator.Interfaces;
using TaxAssistant.Repository.Repositories.Interface;
using TaxAssistant.Repository.Models;

namespace TaxAssistant.Calculator
{
    public class TaxCalculator : ITaxCalculator
    {
        private readonly ITaxRepository _taxRepository;
        private readonly IScheduledTax _scheduledTax;
        private readonly IDuplicateTaxValidator _duplicateTaxValidator;

        public TaxCalculator(
            ITaxRepository taxRepository,
            IScheduledTax scheduledTax,
            IDuplicateTaxValidator duplicateTaxValidator
            )
        {
            _taxRepository = taxRepository;
            _scheduledTax = scheduledTax;
            _duplicateTaxValidator = duplicateTaxValidator;
        }

        public async Task<float?> GetTax(string municipalityName, DateTime onDate)
        {
            var allTaxs = await _taxRepository.GetByMunicipality(municipalityName);
            var appliedScheduleTax = _scheduledTax.GetSchedule(allTaxs, onDate);

            return appliedScheduleTax?.TaxFactor!.Value;
        }

        public async Task AddNewTax(Tax tax)
        {
            var isDuplicate = _duplicateTaxValidator.IsDuplicate(tax);
            if (!isDuplicate)
            {
                try
                {
                    await _taxRepository.Create(tax);
                }
                catch (Exception e)
                {
                    throw new Exception("Not able to Create");
                }
            }
            else
            {
                throw new Exception("Not able to Create");
            }
        }
    }
}