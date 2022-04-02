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
        public override Task<Category> Add(Category obj)
        {
            return base.Add(obj);
        }

        public override Task<Category> Update(Category obj)
        {
            // Logica para atualizar os movimentos que tem relação com categoria
            return base.Update(obj);
        }
        public override Task Delete(Category obj)
        {
            // Logica para deletar os movimentos que tem relação com categoria
            return base.Delete(obj);
        }

        public override async Task<Category?> GetById(int id)
        {
            return await _categoryRepository.GetById(id);
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
