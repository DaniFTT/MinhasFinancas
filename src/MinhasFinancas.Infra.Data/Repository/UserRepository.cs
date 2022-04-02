using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces.Repositories;
using MinhasFinancas.Infra.Data.Configurations;
using System.Linq.Expressions;
using System.Security.Claims;

namespace MinhasFinancas.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextOptions<DataContext> _optionsBuilder;
        public UserRepository(IHttpContextAccessor httpContextAccessor)
        {
            _optionsBuilder = new DbContextOptions<DataContext>();
        }

        public async Task<string> GetUserId(string email)
        {
            try
            {
                using (var data = new DataContext(_optionsBuilder))
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

        public async Task<ApplicationUser?> GetUserById(string id)
        {
            try
            {
                using (var data = new DataContext(_optionsBuilder))
                {
                    return await data.User
                        .Where(u => u.Id.Equals(id))
                        .AsNoTracking()
                        .FirstOrDefaultAsync();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<ApplicationUser>> GetUsers(Expression<Func<ApplicationUser, bool>> exUser)
        {
            using (var data = new DataContext(_optionsBuilder))
            {
                return await data.User.Where(exUser).AsNoTracking().ToListAsync();
            }
        }
    }
}
