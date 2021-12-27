using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Domain.Interfaces.Repositories;
using MinhasFinancas.Infra.Data.Configurations;

namespace MinhasFinancas.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextOptions<Context> _optionsBuilder;
        public UserRepository()
        {
            _optionsBuilder = new DbContextOptions<Context>();
        }

        public async Task<string> RetornaIdUsuario(string email)
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
    }
}
