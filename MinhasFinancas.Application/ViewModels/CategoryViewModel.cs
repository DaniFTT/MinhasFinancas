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
        public int Id { get; private set; }
        public string? Name { get; set; }
        public bool Type { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastEdtion { get; set; }
        public string? UserId { get; set; }
    }
}
