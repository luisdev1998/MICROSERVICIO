using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SharedModels.Models
{
    public class RolesDetails
    {
        [Key]
        public int RoleDetailId { get; set; }
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        [ForeignKey("ActionId")]
        public int ActionId { get; set; }
        public Roles Role { get; set; }
        public Actions Action { get; set; }
    }
}
