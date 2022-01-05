using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces.Repositories;
using MinhasFinancas.Domain.Interfaces.Services;

namespace MinhasFinancas.Domain.Services
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(IBaseRepository<Category> baseRepository, ICategoryRepository categoryRepository) : base(baseRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async override Task<Category> Add<TValidator>(Category obj)
        {
            return await base.Add<TValidator>(obj);
        }

        public async Task<IEnumerable<Category>> ListEntryCategories()
        {
            return await _categoryRepository.ListCategoryByType(true);
        }

        public async Task<IEnumerable<Category>> ListOutputCategories()
        {
            return await _categoryRepository.ListCategoryByType(false);
        }
    }
}
