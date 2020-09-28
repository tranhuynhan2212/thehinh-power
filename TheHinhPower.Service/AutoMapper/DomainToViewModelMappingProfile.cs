using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TheHinhPower.Data.Entities;
using TheHinhPower.Service.ViewModels;

namespace TheHinhPower.Service.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Function, FunctionViewModel>();
            CreateMap<CategoryProduct, CategoryProductViewModel>();
            CreateMap<Product, ProductViewModel>();
        }
    }
}
