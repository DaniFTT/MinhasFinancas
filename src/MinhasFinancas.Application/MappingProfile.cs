using AutoMapper;
using MinhasFinancas.Application.ViewModels;
using MinhasFinancas.Domain.Entities;

namespace MinhasFinancas.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CategoryMap();
        }

        private void CategoryMap()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}
