using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.Dtos;
using OrderService.Interfaces;
using SharedModels.Models;

namespace OrderService.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OrderRepository(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<Orders> CreateOrder(int userId, CreateOrderDto createOrderDto)
        {
            var order = _mapper.Map<Orders>(createOrderDto);
            order.Total = 0m;
            order.UserId = userId;

            var newOrderDetails = new List<OrdersDetails>();

            foreach (var orderDetailDto in createOrderDto.OrderDetails)
            {
                var detail = _mapper.Map<OrdersDetails>(orderDetailDto);

                var product = await _context.Products.FindAsync(detail.ProductId);
                if (product == null)
                {
                    throw new InvalidOperationException("Product not available.");
                }
                else if (product.Stock < detail.Quantity)
                {
                    throw new InvalidOperationException("Insufficient stock.");
                }

                product.Stock -= detail.Quantity;
                _context.Products.Update(product);

                detail.UnitPrice = product.Price;
                order.Total += detail.UnitPrice * detail.Quantity;

                newOrderDetails.Add(detail);
            }

            order.OrderDetail = newOrderDetails;
            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<GetOrderDto> GetOrderDetailById(int orderId)
        {
            var order = await _context.Orders.Include(o => o.OrderDetail).ThenInclude(o => o.Product).FirstOrDefaultAsync(o => o.OrderId == orderId);
            return _mapper.Map<GetOrderDto>(order);
        }
    }
}
