using System;
using TaxAssistant.Repository.Models;

namespace TaxAssistant.Calculator.Interfaces
{
    public interface IDuplicateTaxValidator
    {
        bool IsDuplicate(Tax tax);
    }
}

