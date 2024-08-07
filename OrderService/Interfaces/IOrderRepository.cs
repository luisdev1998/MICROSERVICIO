using OrderService.Dtos;
using SharedModels.Models;

namespace OrderService.Interfaces
{
    public interface IOrderRepository
    {
        Task<Orders> CreateOrder(int userId, CreateOrderDto createOrderDto);
        Task<GetOrderDto> GetOrderDetailById(int orderId);
    }
}
