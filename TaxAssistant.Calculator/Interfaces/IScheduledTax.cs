using System;
using TaxAssistant.Repository.Models;

namespace TaxAssistant.Calculator.Interfaces
{
    public interface IScheduledTax
    {
        Tax GetSchedule(IEnumerable<Tax> taxes, DateTime date);
    }
}

