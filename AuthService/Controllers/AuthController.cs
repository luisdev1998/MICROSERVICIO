using AuthService.Dtos;
using AuthService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/auth/")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            this._authRepository = authRepository;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginRequestDto loginRequestDto)
        {
            var token = await _authRepository.Login(loginRequestDto.Username, loginRequestDto.password);
            if (token == null)
            {
                return BadRequest("User not found");
            }
            return Ok(token);
        }
    }
}
