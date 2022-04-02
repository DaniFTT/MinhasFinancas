using System.ComponentModel.DataAnnotations;

namespace MinhasFinancas.Application.ViewModels.Category
{
    public class CreateUpdateCategoryViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public bool Type { get; set; }
    }
}
