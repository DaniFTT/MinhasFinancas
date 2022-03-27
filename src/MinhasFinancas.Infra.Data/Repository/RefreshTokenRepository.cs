using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces.Repositories;
using MinhasFinancas.Infra.Data.Configurations;
using System.Linq.Expressions;

namespace MinhasFinancas.Infra.Data.Repository
{
    public class RefreshTokenRepository : BaseRepository<RefreshToken>, IRefreshTokenRepository
    {
        private readonly DbContextOptions<Context> _optionsBuilder;
        public RefreshTokenRepository()
        {
            _optionsBuilder = new DbContextOptions<Context>();
        }

        public async Task<RefreshToken?> FindRefreshTokenByExpress(Expression<Func<RefreshToken, bool>> exToken)
        {
            using (var data = new Context(_optionsBuilder))
            {
                return await data.RefreshTokens.FirstOrDefaultAsync(exToken);
            }
        }
    }
}
