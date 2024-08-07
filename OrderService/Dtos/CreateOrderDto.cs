namespace OrderService.Dtos
{
    public class CreateOrderDto
    {
        public DateTime OrderDate { get; set; }
        public List<CreateOrderDetailDto> OrderDetails { get; set; }
    }
}
