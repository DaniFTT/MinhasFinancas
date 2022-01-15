using MinhasFinancas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool Type { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastEdtion { get; set; }
        
        public CategoryViewModel(int id, string? name, bool type, DateTime creationDate, DateTime lastEdtion)
        {
            Id = id;
            Name = name;
            Type = type;
            CreationDate = creationDate;
            LastEdtion = lastEdtion;
        }

        public CategoryViewModel(Domain.Entities.Category c)
        {
            Id =c.Id;
            Name = c.Name;
            Type = c.Type;
            CreationDate = c.CreationDate;
            LastEdtion = c.LastEdtion;       
        }
    }
}
