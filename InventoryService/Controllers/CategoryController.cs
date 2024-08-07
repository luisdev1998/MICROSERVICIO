using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InventoryService.Filters;
using InventoryService.Interfaces;
using InventoryService.Models;

namespace InventoryService.Controllers
{
    [ApiController]
    [Route("api/inventory/[controller]")]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        [HttpPost]
        [Authorization("CreateCategory")]
        public async Task<ActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var category = await _categoryRepository.CreateCategory(createCategoryDto);
            return Created(nameof(GetCategoryById), category);
        }

        [HttpGet]
        [Authorization("ListCategory")]
        public async Task<ActionResult> ListCategory()
        {
            var categoryList = await _categoryRepository.ListCategories();
            return Ok(categoryList);
        }

        [HttpGet("{id:int}")]
        [Authorization("ListCategory")]
        public async Task<ActionResult> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return NotFound("Category not found");
            }
            return Ok(category);
        }
    }
}
