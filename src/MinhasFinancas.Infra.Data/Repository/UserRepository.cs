using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces.Repositories;
using MinhasFinancas.Infra.Data.Configurations;
using System.Linq.Expressions;

namespace MinhasFinancas.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextOptions<Context> _optionsBuilder;
        public UserRepository()
        {
            _optionsBuilder = new DbContextOptions<Context>();
        }

        public async Task<string> GetUserId(string email)
        {
            try
            {
                using (var data = new Context(_optionsBuilder))
                {
                    var usuario = await data.User
                        .Where(u => u.Email.Equals(email))
                        .AsNoTracking()
                        .FirstOrDefaultAsync();

                    if (usuario != null)
                        return usuario.Id;

                    return string.Empty;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public async Task<List<ApplicationUser>> GetUsers(Expression<Func<ApplicationUser, bool>> exUser)
        {
            using (var data = new Context(_optionsBuilder))
            {
                return await data.User.Where(exUser).AsNoTracking().ToListAsync();
            }
        }
    }
}
