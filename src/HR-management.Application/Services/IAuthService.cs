using HR_management.Application.Models.Auth;
using System.Security.Claims;

namespace HR_management.Application.Services
{
    public interface IAuthService
    {
        Task<AuthenticatedResponse?> Login(LoginDto loginDto);
        Task<string> Register(RegisterDto registerDto);
        //string GenerateAccessToken(IEnumerable<Claim> claims, DateTime expireAt);
        //string GenerateRefreshToken();
        //ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
