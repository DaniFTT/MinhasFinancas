using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces.Repositories;

namespace MinhasFinancas.Domain.Services
{
    public class CategoryService : BaseService<Category>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(IBaseRepository<Category> baseRepository, ICategoryRepository categoryRepository) : base(baseRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public override async Task<Category> Add<TValidator>(Category obj)
        {
            return await base.Add<TValidator>(obj);
        }
    }
}
