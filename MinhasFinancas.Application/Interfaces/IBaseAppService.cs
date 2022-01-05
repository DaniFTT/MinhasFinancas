using MinhasFinancas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Interfaces
{
    public interface IBaseAppService<T> where T : class
    {
        Task Add(T Object);
        Task Update(T Object);
        Task Delete(int Id);
        Task<T> GetById(int Id);
        Task<IEnumerable<T>> List();
    }
}
