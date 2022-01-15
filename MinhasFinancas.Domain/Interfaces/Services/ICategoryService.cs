using MinhasFinancas.Domain.Entities;

namespace MinhasFinancas.Domain.Interfaces.Services
{
    public interface ICategoryService : IBaseService<Category>
    {
        Task<IEnumerable<Category>> ListUserCategories();
        Task<IEnumerable<Category>> ListUserEntryCategories();
        Task<IEnumerable<Category>> ListUserOutputCategories();
    }
}
