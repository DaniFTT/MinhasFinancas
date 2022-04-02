using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Application.ViewModels;
using MinhasFinancas.Application.ViewModels.Category;

namespace MinhasFinancas.Application.Interfaces
{
    public interface ICategoryAppService
    {

        Task<IActionResult> Add(CreateUpdateCategoryViewModel Object);
        Task<IActionResult> Update(CreateUpdateCategoryViewModel Object);
        Task<IActionResult> Delete(Guid Id);
        Task<CategoryViewModel?> GetById(Guid Id);
        Task<IEnumerable<CategoryViewModel>> ListUserEntryCategories();
        Task<IEnumerable<CategoryViewModel>> ListUserOutputCategories();
        Task<IEnumerable<CategoryViewModel>> ListUserCategories();
    }
}
