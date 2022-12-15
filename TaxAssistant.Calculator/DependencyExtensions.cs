using System;

using TaxAssistant.Calculator.Interfaces;
using TaxAssistant.Repository;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TaxAssistant.Calculator.Validator;

namespace TaxAssistant.Calculator
{
    public static class DependencyExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient<IDuplicateTaxValidator, DuplicateTaxValidator>();

            services.AddTransient<IScheduledTax, ScheduledTax>();
            services.AddTransient<ITaxCalculator, TaxCalculator>();
            services.ConfigureRepositories(configuration);

            return services;
        }
    }
}

