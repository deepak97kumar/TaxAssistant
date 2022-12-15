using System;
using TaxAssistant.Repository.Models;

namespace TaxAssistant.Repository.Repositories.Interface
{
    public interface IRepository<T>
        where T : class, IEntity
    {
        IQueryable<T> GetAll();
        Task<T> GetById(Guid id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(Guid id);
    }
}

