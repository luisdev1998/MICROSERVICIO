using AutoMapper;
using InventoryService.Data;
using InventoryService.Interfaces;
using InventoryService.Models;
using Microsoft.EntityFrameworkCore;
using SharedModels.Models;

namespace InventoryService.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<Products> CreateProduct(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Products>(createProductDto);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Products> GetProductById(int id)
        {
            var product = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.ProductId == id);
            return product;
        }

        public async Task<List<Products>> ListProducts()
        {
            var productList = await _context.Products.Include(p => p.Category).ToListAsync();
            return productList;
        }
    }
}
