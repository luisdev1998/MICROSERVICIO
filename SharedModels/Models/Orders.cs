using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedModels.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public decimal Total {  get; set; }
        public List<OrdersDetails> OrderDetail { get; set; }
        public Users User { get; set; }
    }
}
