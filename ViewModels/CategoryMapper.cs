using AutoMapper;
using BulkyWeb.Models;
namespace BulkyWeb.ViewModels
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CategoryViewModel>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
            CreateMap<CategoryRequest, Category>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products)); // Nếu cần
            CreateMap<CategoryViewModel, Category>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
            CreateMap<ProductViewModel, Product>();  // Ánh xạ từ ProductViewModel -> Product
            CreateMap<Product, ProductViewModel>();  // Ánh xạ ngược từ Product -> ProductViewModel
        }
    }
}