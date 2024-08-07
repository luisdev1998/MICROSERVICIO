using InventoryService.Models;
using SharedModels.Models;

namespace InventoryService.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Categories> CreateCategory(CreateCategoryDto createCategoryDto);
        Task<List<Categories>> ListCategories();
        Task<Categories> GetCategoryById(int id);
    }
}
