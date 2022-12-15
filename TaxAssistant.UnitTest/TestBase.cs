using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TaxAssistant.Repository;

namespace TaxAssistant.UnitTest
{
    public abstract class TestBase : IDisposable
    {
        internal readonly TaxAssistantContext _context;

        public TestBase()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<TaxAssistantContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .UseInternalServiceProvider(serviceProvider);

            _context = new TaxAssistantContext(builder.Options);
        }

        public void CleanUp<T>(List<T> entities)
            where T : class, TaxAssistant.Repository.Models.IEntity
        {
            foreach (var item in entities)
            {
                _context.Remove<T>(item);
                _context.SaveChanges();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

