using AutoMapper;
using FluentValidation;
using MinhasFinancas.Application.Interfaces;
using MinhasFinancas.Application.ViewModels;
using MinhasFinancas.Domain.Entities;
using MinhasFinancas.Domain.Interfaces.Services;
using MinhasFinancas.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasFinancas.Application.Applications
{
    public class CategoryAppService : ICategoryAppService
    {
        protected readonly IMapper _mapper;
        protected readonly ICategoryService _categoryService;

        public CategoryAppService(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task Add(CategoryViewModel Object)
        {
            await _categoryService.Add<CategoryValidator>(_mapper.Map<Category>(Object));
        }

        public async Task Update(CategoryViewModel Object)
        {
            await _categoryService.Update<CategoryValidator>(_mapper.Map<Category>(Object));
        }

        public async Task Delete(int Id)
        {
            await _categoryService.Delete(Id);
        }

        public async Task<CategoryViewModel> GetById(int Id)
        {
            return _mapper.Map<CategoryViewModel>(await _categoryService.GetById(Id));
        }

        public async Task<IEnumerable<CategoryViewModel>> List()
        {
            return _mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryService.List());
        }

        public async Task<IEnumerable<CategoryViewModel>> ListEntryCategories()
        {
            return _mapper.Map<List<CategoryViewModel>>(await _categoryService.ListEntryCategories());
        }

        public async Task<IEnumerable<CategoryViewModel>> ListOutputCategories()
        {
            return _mapper.Map<List<CategoryViewModel>>(await _categoryService.ListOutputCategories());
        }
    }
}
