using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces.Repositories;
using MinhasFinancas.Domain.Interfaces.Services;


namespace MinhasFinancas.Domain.Services
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAuthenticationService _userService;
        public CategoryService(IBaseRepository<Category> baseRepository, ICategoryRepository categoryRepository, IAuthenticationService userService) : base(baseRepository)
        {
            _categoryRepository = categoryRepository;
            _userService = userService;
        }
        public override Task<Category> Add(Category obj)
        {
            obj.UserId = _userService.GetIdLoggedUser();

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
            var UserId = _userService.GetIdLoggedUser();
            return await _categoryRepository.GetById(id, UserId);
        }

        public async Task<IEnumerable<Category>> ListUserEntryCategories()
        {
            var userId = _userService.GetIdLoggedUser();
            return await _categoryRepository.ListUserCategoryByType(false, userId);
        }

        public async Task<IEnumerable<Category>> ListUserOutputCategories()
        {
            var userId = _userService.GetIdLoggedUser();
            return await _categoryRepository.ListUserCategoryByType(true, userId);
        }

        public async Task<IEnumerable<Category>> ListUserCategories()
        {
            var userId = _userService.GetIdLoggedUser();
            return await _categoryRepository.ListUserCategories(userId);
        }
    }
}
