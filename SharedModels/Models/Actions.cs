using System.ComponentModel.DataAnnotations;

namespace SharedModels.Models
{
    public class Actions
    {
        [Key]
        public int ActionId { get; set; }
        public string ActionName { get; set; }
    }
}
