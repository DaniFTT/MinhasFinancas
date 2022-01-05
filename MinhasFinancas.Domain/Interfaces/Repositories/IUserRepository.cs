using MinhasFinancas.Domain.Entities;
using System.Linq.Expressions;

namespace MinhasFinancas.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<string> GetUserId(string email);
        Task<List<ApplicationUser>> GetUsers(Expression<Func<ApplicationUser, bool>> exNoticia);
    }
}
