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
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserRepository(IHttpContextAccessor httpContextAccessor)
        {
            _optionsBuilder = new DbContextOptions<DataContext>();
            _httpContextAccessor = httpContextAccessor;
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
        public async Task<ApplicationUser?> GetCurrentUserById()
        {
            try
            {
                var currentUserId = GetCurrentUserId();
                using (var data = new DataContext(_optionsBuilder))
                {
                    return await data.User
                        .Where(u => u.Id.Equals(currentUserId))
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

        public string GetCurrentUserId()
        {
            var identity = _httpContextAccessor.HttpContext?.User?.Identity as ClaimsIdentity;
            var result = string.Empty;

            if (identity?.IsAuthenticated ?? false)
            {
                result = identity?.FindFirst("userId")?.Value;
            }

            return result ?? string.Empty;
        }

    }
}
