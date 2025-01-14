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
            CreateMap<ProductViewModel, Product>()
                 .ForMember(dest => dest.Category, opt => opt.Ignore()) // Bỏ qua Category để tránh lỗi ánh xạ vòng
                 .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));



        }
    }
}
