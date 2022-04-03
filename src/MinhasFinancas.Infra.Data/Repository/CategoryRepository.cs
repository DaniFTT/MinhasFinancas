using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces.Repositories;
using MinhasFinancas.Infra.Data.Configurations;

namespace MinhasFinancas.Infra.Data.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly DbContextOptions<DataContext> _optionsBuilder;
        public CategoryRepository(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _optionsBuilder = new DbContextOptions<DataContext>();
        }

        public override async Task AddAsync(Category obj)
        {
            using (var data = new DataContext(_optionsBuilder))
            {
                obj.UserId = GetCurrentUserId();
                await data.Set<Category>().AddAsync(obj);
                await data.SaveChangesAsync();
            }
        }

        public override async Task<Category?> GetByIdAsync(Guid Id)
        {
            using (var data = new DataContext(_optionsBuilder))
            {
                return await data.Set<Category>().Where(c => c.UserId == GetCurrentUserId() && c.Id == Id).FirstOrDefaultAsync();
            }
        }

        public async Task<IEnumerable<Category>> ListUserCategories()
        {
            using (var data = new DataContext(_optionsBuilder))
            {
                return await data.Set<Category>().AsNoTracking().Where(c => c.UserId == GetCurrentUserId()).ToListAsync();
            }
        }

        public async Task<IEnumerable<Category>> ListUserCategoryByType(bool type)
        {
            using (var data = new DataContext(_optionsBuilder))
            {
                return await data.Set<Category>().AsNoTracking().Where(c => c.UserId == GetCurrentUserId() && c.Type == type).ToListAsync();
            }
        }
    }
}
