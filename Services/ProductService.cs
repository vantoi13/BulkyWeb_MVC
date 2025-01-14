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

        public async Task<Product> Create(ProductRequest request)
        {
            var product = _mapper.Map<Product>(request);
            if (request.Image != null)
            {
                // Save image logic here
            }
            _context.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<bool> Update(int id, ProductViewModel product)
        {
            _context.Update(_mapper.Map<Product>(product));
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
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
