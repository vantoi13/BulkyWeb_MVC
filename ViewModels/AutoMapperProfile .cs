// ViewModels/AutoMapperProfile.cs
using AutoMapper;
using BulkyWeb.Models;
using BulkyWeb.ViewModels;

namespace BulkyWeb.ViewModels
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category!.Name));
            CreateMap<ProductRequest, Product>();
        }
    }
}
