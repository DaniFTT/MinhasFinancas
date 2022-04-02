using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces.Repositories;
using MinhasFinancas.Infra.Data.Configurations;

namespace MinhasFinancas.Infra.Data.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly DbContextOptions<DataContext> _optionsBuilder;
        public CategoryRepository()
        {
            _optionsBuilder = new DbContextOptions<DataContext>();
        }

        public override async Task<Category?> GetById(int Id)
        {
            using (var data = new DataContext(_optionsBuilder))
            {

                return await data.Set<Category>().Where(c => c.UserId == _currentUserId && c.Id == Id).FirstOrDefaultAsync();
            }
        }

        public async Task<IEnumerable<Category>> ListUserCategories()
        {
            using (var data = new DataContext(_optionsBuilder))
            {
                return await data.Set<Category>().AsNoTracking().Where(c => c.UserId == _currentUserId).ToListAsync();
            }
        }

        public async Task<IEnumerable<Category>> ListUserCategoryByType(bool type)
        {
            using (var data = new DataContext(_optionsBuilder))
            {
                return await data.Set<Category>().AsNoTracking().Where(c => c.Type == type && c.UserId == _currentUserId).ToListAsync();
            }
        }
    }
}
