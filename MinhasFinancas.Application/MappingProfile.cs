using AutoMapper;
using MinhasFinancas.Application.ViewModels;
using MinhasFinancas.Application.ViewModels.User;
using MinhasFinancas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
