using BulkyWeb.ViewModels;
namespace BulkyWeb.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetProducts();
        Task<ProductViewModel> GetProduct(int id);
        Task<bool> Create(ProductRequest request);
        Task<bool> Update(ProductRequest request, int id);
        Task<bool> Delete(int id);
    }
} 