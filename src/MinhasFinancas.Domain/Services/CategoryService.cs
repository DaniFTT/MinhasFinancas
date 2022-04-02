using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces.Repositories;
using MinhasFinancas.Domain.Interfaces.Services;


namespace MinhasFinancas.Domain.Services
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public override Task<Category> AddAsync(Category obj)
        {
            return base.AddAsync(obj);
        }

        public override Task<Category> UpdateAsync(Category obj)
        {
            // Logica para atualizar os movimentos que tem relação com categoria
            return base.UpdateAsync(obj);
        }

        public override Task DeleteAsync(Category obj)
        {
            // Logica para deletar os movimentos que tem relação com categoria
            return base.DeleteAsync(obj);
        }

        public override async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Category>> ListUserEntryCategories()
        {
            return await _categoryRepository.ListUserCategoryByType(false);
        }

        public async Task<IEnumerable<Category>> ListUserOutputCategories()
        {
            return await _categoryRepository.ListUserCategoryByType(true);
        }

        public async Task<IEnumerable<Category>> ListUserCategories()
        {
            return await _categoryRepository.ListUserCategories();
        }
    }
}
