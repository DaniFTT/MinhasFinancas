namespace MinhasFinancas.Application.ViewModels
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool Type { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastEdtion { get; set; }

        public CategoryViewModel(Guid id, string? name, bool type, DateTime creationDate, DateTime lastEdtion)
        {
            Id = id;
            Name = name;
            Type = type;
            CreationDate = creationDate;
            LastEdtion = lastEdtion;
        }

        public CategoryViewModel(Domain.Entities.Category c)
        {
            Id = c.Id;
            Name = c.Name;
            Type = c.Type;
            CreationDate = c.CreationDate;
            LastEdtion = c.LastEdtion;
        }
    }
}
