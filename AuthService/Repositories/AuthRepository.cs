using AuthService.Data;
using AuthService.Helpers;
using AuthService.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            this._context = context;
            this._configuration = configuration;
        }

        public async Task<string> Login(string username, string password)
        {
            var user = await _context.Users.Include(u => u.Role).ThenInclude(r => r.RolesDetail).ThenInclude(rd => rd.Action).FirstOrDefaultAsync(u => u.Username == username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return null;
            }

            var token = JwtTokenGenerator.GenerateToken(user, _configuration["Jwt:SigninKey"], int.Parse(_configuration["Jwt:TokenExpirationTime"]));
            return token;
        }
    }
}
