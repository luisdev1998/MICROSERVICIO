using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderService.Dtos;
using OrderService.Filters;
using OrderService.Interfaces;
using System.Security.Claims;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/order/[controller]")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        [HttpPost]
        [Authorization("CreateOrder")]
        public async Task<ActionResult> CreateOrder(CreateOrderDto createOrderDto)
        {
            try
            {
                var userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).ToString());
                var order = await _orderRepository.CreateOrder(userId, createOrderDto);
                return CreatedAtAction(nameof(CreateOrder), order);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetOrderDetailById(int id)
        {
            var order = await _orderRepository.GetOrderDetailById(id);
            if (order == null)
            {
                return NotFound("Order not found");
            }
            return Ok(order);
        }
    }
}
