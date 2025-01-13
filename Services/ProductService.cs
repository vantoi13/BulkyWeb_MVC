// Services/ProductService.cs
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

        public ProductService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public async Task<bool> Create(ProductRequest request)
        {
            var product = _mapper.Map<Product>(request);
            if (request.Image != null)
            {
                // Save image logic here
            }
            _context.Products.Add(product);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(int id, ProductRequest request)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _mapper.Map(request, product);
            if (request.Image != null)
            {
                // Update image logic here
            }

            _context.Products.Update(product);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<bool> Update(ProductRequest request, int id)
        {
            throw new NotImplementedException();
        }
    }
}
