using AutoMapper;
using OrderService.Dtos;
using SharedModels.Models;

namespace OrderService.Data
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<CreateOrderDto, Orders>();
            CreateMap<CreateOrderDetailDto, OrdersDetails>();

            CreateMap<OrdersDetails, GetOrderDetailsDto>();
            CreateMap<Orders, GetOrderDto>()
            .ForMember(dest => dest.OrdersDetails, opt => opt.MapFrom(src => src.OrderDetail));
        }
    }
}
