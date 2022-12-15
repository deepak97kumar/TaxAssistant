using System;
namespace TaxAssistant.Repository.Models
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}

