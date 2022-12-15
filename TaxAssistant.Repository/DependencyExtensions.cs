using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxAssistant.Repository.Repositories;
using TaxAssistant.Repository.Repositories.Interface;

namespace TaxAssistant.Repository
{
    public static class DependencyExtensions
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services,
            IConfiguration configuration)
        {
            //services.AddTransient<ITaxAssistantContext, TaxAssistantContext>();
            services.AddTransient<ITaxRepository, TaxRepository>();

            return services;
        }
    }
}

