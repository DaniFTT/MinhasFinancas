using FluentValidation;
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
        public virtual async Task<T> Add<TValidator>(T obj) where TValidator : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            await _baseRepository.Add(obj);
            return obj;
        }

        public virtual async Task<T> Update<TValidator>(T obj) where TValidator : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            await _baseRepository.Update(obj);
            return obj;
        }
        public virtual async Task<T?> GetById(int id) => await _baseRepository.GetById(id);

        public virtual async Task<IEnumerable<T>> List() => await _baseRepository.List();

        public virtual async Task Delete(int id) => await _baseRepository.Delete(id);

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
