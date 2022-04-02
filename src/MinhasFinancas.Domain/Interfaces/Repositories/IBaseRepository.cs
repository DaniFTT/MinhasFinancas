using MinhasFinancas.Domain.Entities;

namespace MinhasFinancas.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task AddAsync(T Object);
        Task UpdateAsync(T Object);
        Task DeleteAsync(T Object);
        Task DeleteByIdAsync(Guid id);
        Task<T?> GetByIdAsync(Guid Id);
        Task<IEnumerable<T>> ListAsync();
    }
}
