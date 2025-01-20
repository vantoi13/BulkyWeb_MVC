// Services/IProductService.cs
using BulkyWeb.Models;
using BulkyWeb.ViewModels;

namespace BulkyWeb.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetProducts();
        Task<PaginatedList<ProductViewModel>> GetAllFilter(string sortOrder, string currentFilter, string searchString, int? pageNumber, int pageSize);
        Task<ProductViewModel> GetProduct(int id);
        Task<Product> Create(ProductRequest request);
        Task<bool> Update(int id, ProductViewModel product);
        Task<bool> Delete(int id);
        bool ProductExists(int id);
    }
}
