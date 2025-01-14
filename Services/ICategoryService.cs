using BulkyWeb.Models;
using BulkyWeb.ViewModels;

namespace BulkyWeb.Services
{
    public interface ICategoryService
    {
    Task<IEnumerable<CategoryViewModel>> GetCategorys();
    Task<CategoryViewModel> GetCategory(int id);
    Task<Category> Create(CategoryRequest request);
    Task<bool> Update (int id, CategoryViewModel category);
    Task<bool> Delete(int id);
    bool CategoryExists(int id);
    }
}