using SharedModels.Models;

namespace OrderService.Dtos
{
    public class GetOrderDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public decimal Total { get; set; }
        public List<GetOrderDetailsDto> OrdersDetails { get; set; }
    }
}
