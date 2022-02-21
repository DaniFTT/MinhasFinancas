using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Domain.Entities;

namespace MinhasFinancas.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<T> Add(T obj);
        Task<T> Update(T obj);
        Task Delete(T obj);
        Task<T?> GetById(int id);
        Task<IEnumerable<T>> List();
    }
}
