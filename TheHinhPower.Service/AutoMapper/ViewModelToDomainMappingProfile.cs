using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TheHinhPower.Data.Entities;
using TheHinhPower.Service.ViewModels;

namespace TheHinhPower.Service.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<FunctionViewModel, Function>();
            CreateMap<CategoryProductViewModel, CategoryProduct>();
            CreateMap<ProductViewModel, Product>();
        }
    }
}
