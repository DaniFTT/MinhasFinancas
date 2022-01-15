using MinhasFinancas.Domain.Entities;

namespace MinhasFinancas.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task Add(T Object);
        Task Update(T Object);
        Task Delete(T Object);
        Task<T?> GetById(int Id);
        Task<IEnumerable<T>> List();
    }
}
