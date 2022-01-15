using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Domain.Entities;

namespace MinhasFinancas.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<T> Add<TValidator>(T obj) where TValidator : AbstractValidator<T>;
        Task<T> Update<TValidator>(T obj) where TValidator : AbstractValidator<T>;
        Task Delete(T obj);
        Task<T?> GetById(int id);
        Task<IEnumerable<T>> List();
    }
}
