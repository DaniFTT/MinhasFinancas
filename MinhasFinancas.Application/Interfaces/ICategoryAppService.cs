using MinhasFinancas.Application.ViewModels;

namespace MinhasFinancas.Application.Interfaces
{
    public interface ICategoryAppService : IBaseAppService<CategoryViewModel>
    {
        Task<IEnumerable<CategoryViewModel>> ListEntryCategories();
        Task<IEnumerable<CategoryViewModel>> ListOutputCategories();
    }
}
