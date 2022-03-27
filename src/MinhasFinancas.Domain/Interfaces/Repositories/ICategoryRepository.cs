using MinhasFinancas.Domain.Entities;

namespace MinhasFinancas.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<Category?> GetById(int Id, string? UserId);
        Task<IEnumerable<Category>> ListUserCategoryByType(bool type, string? UserId);
        Task<IEnumerable<Category>> ListUserCategories(string? UserId);
    }
}
