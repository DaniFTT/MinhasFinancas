using Microsoft.AspNetCore.Http;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces.Repositories;
using MinhasFinancas.Domain.Interfaces.Services;
using System.Security.Claims;

namespace MinhasFinancas.Domain.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public virtual async Task<T> AddAsync(T obj)
        {
            obj.CreationDate = DateTime.Now;
            obj.LastEdtion = DateTime.Now;
            obj.IsDeleted = false;
            obj.GenerateId();
            await _baseRepository.AddAsync(obj);
            return obj;
        }

        public virtual async Task<T> UpdateAsync(T obj)
        {
            obj.LastEdtion = DateTime.Now;
            obj.IsDeleted = false;
            await _baseRepository.UpdateAsync(obj);
            return obj;
        }
        public virtual async Task DeleteAsync(T obj) => await _baseRepository.DeleteAsync(obj);

        public virtual async Task DeleteByIdAsync(Guid id) => await _baseRepository.DeleteByIdAsync(id);

        public virtual async Task<T?> GetByIdAsync(Guid id) => await _baseRepository.GetByIdAsync(id);

        public virtual async Task<IEnumerable<T>> ListAsync() => await _baseRepository.ListAsync();

    }
}
