using System.ComponentModel.DataAnnotations;

namespace SharedModels.Models
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<RolesDetails> RolesDetail { get; set; }
    }
}
