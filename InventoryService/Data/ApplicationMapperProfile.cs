using AutoMapper;
using InventoryService.Models;
using SharedModels.Models;

namespace InventoryService.Data
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<CreateCategoryDto, Categories>();
            CreateMap<CreateProductDto, Products>();
        }
    }
}
