using MinhasFinancas.Domain.Entities;

namespace MinhasFinancas.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<T> AddAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task DeleteAsync(T obj);
        Task DeleteByIdAsync(Guid id);
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> ListAsync();
    }
}
