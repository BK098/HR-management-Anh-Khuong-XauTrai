using HR_management.Application.Models.Auth;
using HR_management.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var res = await _authService.Login(loginDto);
            return Ok(res);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var res = await _authService.Register(registerDto);
            return Ok(res);
        }
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenDto tokenDto)
        {
            var response = await _authService.RefreshToken(tokenDto);
            if (response == null)
            {
                return Unauthorized();
            }
            return Ok(response);
        }
    }
}
