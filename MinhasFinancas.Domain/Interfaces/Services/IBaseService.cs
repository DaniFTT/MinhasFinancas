using FluentValidation;
using MinhasFinancas.Domain.Entities;

namespace MinhasFinancas.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<T> Add<TValidator>(T obj) where TValidator : AbstractValidator<T>;
        Task<T> Update<TValidator>(T obj) where TValidator : AbstractValidator<T>;
        Task Delete(int id);
        Task<T?> GetById(int id);
        Task<IEnumerable<T>> List();
    }
}
