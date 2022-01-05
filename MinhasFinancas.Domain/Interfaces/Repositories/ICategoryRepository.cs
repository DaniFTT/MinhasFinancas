using MinhasFinancas.Domain.Entities;

namespace MinhasFinancas.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<IEnumerable<Category>> ListCategoryByType(bool type); 
    }
}
