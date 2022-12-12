using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxAssistant.Repository.Models
{
    public class Tax
    {
        public Guid Id { get; set; }
        public string? MunicipalityName { get; set; }
        public string? TaxType { get; set; }
        public DateTime? ValidFrom { get; set;}
        public DateTime? ValidUntil { get; set;}
        public float? TaxFactor { get; set; }
    }
}
