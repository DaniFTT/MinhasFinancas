using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces.Repositories;
using MinhasFinancas.Infra.Data.Configurations;

namespace MinhasFinancas.Infra.Data.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly DbContextOptions<Context> _optionsBuilder;
        public CategoryRepository()
        {
            _optionsBuilder = new DbContextOptions<Context>();
        }

        public async Task<Category?> GetById(int Id, string? UserId)
        {
            using (var data = new Context(_optionsBuilder))
            {
                return await data.Set<Category>().Where(c => c.UserId == UserId && c.Id == Id).FirstOrDefaultAsync();
            }
        }

        public async Task<IEnumerable<Category>> ListUserCategories(string? UserId)
        {
            using (var data = new Context(_optionsBuilder))
            {
                return await data.Set<Category>().AsNoTracking().Where(c => c.UserId == UserId).ToListAsync();
            }
        }

        public async Task<IEnumerable<Category>> ListUserCategoryByType(bool type, string? UserId)
        {
            using (var data = new Context(_optionsBuilder))
            {
                return await data.Set<Category>().AsNoTracking().Where(c => c.Type == type && c.UserId == UserId).ToListAsync();
            }
        }
    }
}
