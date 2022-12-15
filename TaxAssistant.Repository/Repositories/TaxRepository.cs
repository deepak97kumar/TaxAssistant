using System;
using Microsoft.EntityFrameworkCore;

using TaxAssistant.Repository.Models;
using TaxAssistant.Repository.Repositories.Interface;

namespace TaxAssistant.Repository.Repositories
{
    public class TaxRepository : Repository<Tax>, ITaxRepository
    {
        public TaxRepository(TaxAssistantContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Tax>> GetByMunicipality(string name)
        {
            var taxes = await GetAll()
                .Where(t => t.MunicipalityName == name)
                .ToListAsync();

            return taxes;
        }
    }
}

