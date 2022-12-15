using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxAssistant.Repository.Models;

namespace TaxAssistant.Repository
{
    public class TaxAssistantContext : DbContext
    {
        public TaxAssistantContext(DbContextOptions<TaxAssistantContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tax> Taxes { get; set; } = null!;
    }
}
