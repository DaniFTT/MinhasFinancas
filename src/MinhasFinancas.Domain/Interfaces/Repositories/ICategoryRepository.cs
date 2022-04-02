using MinhasFinancas.Domain.Entities;

namespace MinhasFinancas.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<IEnumerable<Category>> ListUserCategoryByType(bool type);
        Task<IEnumerable<Category>> ListUserCategories();
    }
}
