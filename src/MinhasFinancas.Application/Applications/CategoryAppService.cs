using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Application.Interfaces;
using MinhasFinancas.Application.ViewModels;
using MinhasFinancas.Application.ViewModels.Category;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces.Services;

namespace MinhasFinancas.Application.Applications
{
    public class CategoryAppService : ICategoryAppService
    {
        protected readonly ICategoryService _categoryService;

        public CategoryAppService(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Add(CreateUpdateCategoryViewModel categoryViewModel)
        {
            var cat = new Category()
            {
                Name = categoryViewModel.Name,
                Type = categoryViewModel.Type,
            };
            return new ObjectResult(await _categoryService.Add(cat));
        }

        public async Task<IActionResult> Update(CreateUpdateCategoryViewModel categoryViewModel)
        {
            var cat = await _categoryService.GetById(categoryViewModel.Id);
            if (cat == null)
                throw new Exception("Categoria não encontrada");

            cat.Name = categoryViewModel.Name;

            return new ObjectResult(await _categoryService.Update(cat));
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var cat = await _categoryService.GetById(Id);
            if (cat == null)
                throw new Exception("Categoria não encontrada");

            await _categoryService.Delete(cat);

            return new ObjectResult($"Categoria {cat?.Name} excluida com sucesso!");
        }

        public async Task<CategoryViewModel?> GetById(int Id)
        {
            var categoria = await _categoryService.GetById(Id);
            if (categoria == null)
                throw new Exception("Categoria não encontrada");

            return new CategoryViewModel(categoria);
        }

        public async Task<IEnumerable<CategoryViewModel>> ListUserEntryCategories()
        {
            var categorias = (await _categoryService.ListUserEntryCategories()).ToList();
            return new List<CategoryViewModel>(categorias.Select(c => new CategoryViewModel(c)));
        }

        public async Task<IEnumerable<CategoryViewModel>> ListUserOutputCategories()
        {
            var categorias = (await _categoryService.ListUserOutputCategories()).ToList();
            return new List<CategoryViewModel>(categorias.Select(c => new CategoryViewModel(c)));
        }

        public async Task<IEnumerable<CategoryViewModel>> ListUserCategories()
        {
            var categorias = (await _categoryService.ListUserCategories()).ToList();
            return new List<CategoryViewModel>(categorias.Select(c => new CategoryViewModel(c)));
        }

    }
}
