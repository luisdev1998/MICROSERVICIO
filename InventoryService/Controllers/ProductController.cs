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
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository ,ICategoryRepository categoryRepository)
        {
            this._productRepository = productRepository;
            this._categoryRepository = categoryRepository;
        }

        [HttpPost]
        [Authorization("CreateProduct")]
        public async Task<ActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var category = await _categoryRepository.GetCategoryById(createProductDto.CategoryId);
            if (category == null)
            {
                return NotFound("Category not found");
            }
            var product = await _productRepository.CreateProduct(createProductDto);
            return CreatedAtAction(nameof(CreateProduct) ,product);
        }

        [HttpGet]
        [Authorization("ListProduct")]
        public async Task<ActionResult> ListProduct()
        {
            var productList = await _productRepository.ListProducts();
            return Ok(productList);
        }

        [HttpGet("{id:int}")]
        [Authorization("ListProduct")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }
            return Ok(product);
        }
    }
}
