using SharedModels.Models;

namespace OrderService.Dtos
{
    public class GetOrderDetailsDto
    {
        public int OrderDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Products Product { get; set; }
    }
}
