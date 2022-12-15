using System;
using TaxAssistant.Calculator.Interfaces;
using TaxAssistant.Repository.Models;
using TaxAssistant.Repository.Repositories.Interface;

namespace TaxAssistant.Calculator.Validator
{
    public class DuplicateTaxValidator : IDuplicateTaxValidator
    {
        private readonly ITaxRepository _taxRepository;

        public DuplicateTaxValidator(ITaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
        }

        public bool IsDuplicate(Tax tax)
        {
            var isAvailable = _taxRepository.GetAll()
                .Where(t => t.MunicipalityName == tax.MunicipalityName)
                .Where(t => t.TaxType == tax.TaxType)
                .Where(t => t.ValidFrom == tax.ValidFrom)
                .Where(t => t.ValidUntil == tax.ValidUntil)
                .Any();

            return isAvailable;
        }
    }
}

