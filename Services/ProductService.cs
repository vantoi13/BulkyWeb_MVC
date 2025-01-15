// Services/ProductService.cs
using System.Net.Http.Headers;
using AutoMapper;
using BulkyWeb.Data;
using BulkyWeb.Models;
using BulkyWeb.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public ProductService(ApplicationDbContext context, IMapper mapper, IStorageService storageService)
        {
            _context = context;
            _mapper = mapper;
            _storageService = storageService;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName!.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }
        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            var products = await _context.Products.Include(p => p.Category).ToListAsync();
            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }

        public async Task<ProductViewModel> GetProduct(int id)
        {
            var product = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
            return _mapper.Map<ProductViewModel>(product);
        }

        public async Task<Product> Create(ProductRequest request)
        {
            var product = _mapper.Map<Product>(request);
            // Save image file
            if (request.Image != null)
            {
                product.ImagePath = await SaveFile(request.Image);
            }
            _context.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<bool> Update(int id, ProductViewModel product)
        {
            if (product.Image != null)
            {
                if (!string.IsNullOrEmpty(product.ImagePath))
                    await _storageService.DeleteFileAsync(product.ImagePath.Replace("/" + USER_CONTENT_FOLDER_NAME + "/", ""));
                product.ImagePath = await SaveFile(product.Image);
            }
            _context.Update(_mapper.Map<Product>(product));
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                if (!string.IsNullOrEmpty(product.ImagePath))
                    await _storageService.DeleteFileAsync(product.ImagePath.Replace("/" + USER_CONTENT_FOLDER_NAME + "/", ""));
                _context.Products.Remove(product);
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
