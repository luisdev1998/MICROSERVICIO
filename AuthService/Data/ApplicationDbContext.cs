using Microsoft.EntityFrameworkCore;
using SharedModels.Models;

namespace AuthService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) {}
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Actions> Actions { get; set; }
        public DbSet<RolesDetails> RolesDetails { get; set; }
    }
}
