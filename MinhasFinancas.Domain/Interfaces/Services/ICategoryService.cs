using MinhasFinancas.Domain.Entities;

namespace MinhasFinancas.Domain.Interfaces.Services
{
    public interface ICategoryService : IBaseService<Category>
    {
        Task<IEnumerable<Category>> ListEntryCategories();
        Task<IEnumerable<Category>> ListOutputCategories();
    }
}
