using System;
using TaxAssistant.Repository.Models;

namespace TaxAssistant.Calculator.Interfaces
{
    public interface ITaxCalculator
    {
        Task<float?> GetTax(string municipalityName, DateTime onDate);
        Task AddNewTax(Tax tax);
    }
}

