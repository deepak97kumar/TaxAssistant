using System;
using TaxAssistant.Calculator.Interfaces;
using TaxAssistant.Repository.Models;
using static TaxAssistant.Calculator.Helpers.Constants;

namespace TaxAssistant.Calculator
{
    public class ScheduledTax : IScheduledTax
    {
        public Tax GetSchedule(IEnumerable<Tax> taxes, DateTime date)
        {
            var dailyTax = GetDailySchedule(taxes, date);

            if (dailyTax is not null)
                return dailyTax;

            var weeklyTax = GetTaxByScheduleRange(taxes, date, Weekly);
            if (weeklyTax is not null)
                return weeklyTax;

            var monthlyTax = GetTaxByScheduleRange(taxes, date, Monthly);
            if (monthlyTax is not null)
                return monthlyTax;

            return GetTaxByScheduleRange(taxes, date, Yearly);
        }

        private Tax GetDailySchedule(IEnumerable<Tax> taxes, DateTime date)
        {
            var dailyTaxes = taxes
                .Where(t => t.TaxType == Daily)
                .Where(t => t.ValidFrom!.Value.Date.CompareTo(date) == 0)
                .FirstOrDefault();

            return dailyTaxes!;
        }

        private Tax GetTaxByScheduleRange(IEnumerable<Tax> taxes, DateTime date, string Mode)
        {
            var tax = taxes
                .Where(t => t.TaxType!.ToLower() == Mode.ToLower())
                .Where(t => date.CompareTo(t.ValidFrom!.Value.Date) >= 0 && date.CompareTo(t.ValidUntil!.Value.Date) <= 0)
                .FirstOrDefault();

            return tax!;
        }
    }
}

