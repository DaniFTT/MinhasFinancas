using MinhasFinancas.Domain.Entities;
using System.Linq.Expressions;

namespace MinhasFinancas.Domain.Interfaces.Repositories
{
    public interface IRefreshTokenRepository : IBaseRepository<RefreshToken>
    {
        Task<RefreshToken?> FindRefreshTokenByExpress(Expression<Func<RefreshToken, bool>> exToken);
    }
}
