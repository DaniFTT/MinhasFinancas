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

        public async Task<IEnumerable<Category>> ListCategoryByType(bool type)
        {
            using (var data = new Context(_optionsBuilder))
            {
                return await data.Set<Category>().AsNoTracking().Where(c => c.Type == type).ToListAsync();
            }
        }
    }
}
