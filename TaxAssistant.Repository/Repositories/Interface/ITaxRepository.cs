using System;
using TaxAssistant.Repository.Models;

namespace TaxAssistant.Repository.Repositories.Interface
{
    public interface ITaxRepository : IRepository<Tax>
    {
        Task<IEnumerable<Tax>> GetByMunicipality(string name);
    }
}

