using InventoryService.Models;
using SharedModels.Models;

namespace InventoryService.Interfaces
{
    public interface IProductRepository
    {
        Task<Products> CreateProduct(CreateProductDto createProductDto);
        Task<List<Products>> ListProducts();
        Task<Products> GetProductById(int id);
    }
}
