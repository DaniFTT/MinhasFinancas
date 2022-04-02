using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces.Repositories;
using MinhasFinancas.Domain.Interfaces.Services;

namespace MinhasFinancas.Domain.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public virtual async Task<T> Add(T obj)
        {
            obj.CreationDate = DateTime.Now;
            obj.LastEdtion = DateTime.Now;
            obj.isDeleted = false;
            await _baseRepository.Add(obj);
            return obj;
        }

        public virtual async Task<T> Update(T obj)
        {
            obj.LastEdtion = DateTime.Now;
            obj.isDeleted = false;
            await _baseRepository.Update(obj);
            return obj;
        }
        public virtual async Task<T?> GetById(int id) => await _baseRepository.GetById(id);

        public virtual async Task<IEnumerable<T>> List() => await _baseRepository.List();

        public virtual async Task Delete(T obj) => await _baseRepository.Delete(obj);
    }
}
