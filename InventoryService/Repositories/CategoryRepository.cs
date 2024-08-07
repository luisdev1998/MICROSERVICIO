using AutoMapper;
using Microsoft.EntityFrameworkCore;
using InventoryService.Data;
using InventoryService.Interfaces;
using InventoryService.Models;
using SharedModels.Models;

namespace InventoryService.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<Categories> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Categories>(createCategoryDto);
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Categories> GetCategoryById(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
            return category;
        }

        public async Task<List<Categories>> ListCategories()
        {
            var categoryList = await _context.Categories.ToListAsync();
            return categoryList;
        }
    }
}
