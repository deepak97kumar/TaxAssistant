using System;

using Microsoft.EntityFrameworkCore;

using TaxAssistant.Repository.Models;
using TaxAssistant.Repository.Repositories.Interface;

namespace TaxAssistant.Repository.Repositories
{
    public abstract class Repository<T> : IRepository<T>
        where T : class, IEntity
    {
        private readonly TaxAssistantContext _context;

        public Repository(TaxAssistantContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var entity = await GetById(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<T> GetById(Guid id)
        {
            return (await _context.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == id))!;
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

