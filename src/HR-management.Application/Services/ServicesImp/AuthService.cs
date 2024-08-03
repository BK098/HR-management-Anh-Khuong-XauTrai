using AutoMapper;
using HR_management.Application.Models.Auth;
using HR_management.Application.Services.DataAccess.Interfaces;
using HR_management.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HR_management.Application.Services.ServicesImp
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly UserManager<Employee> _userManager;
        private readonly SignInManager<Employee> _signInManager;
        private readonly IDepartmentDataAccess _departmentDataAccess;
        public AuthService(IConfiguration configuration, IMapper mapper, SignInManager<Employee> signInManager, UserManager<Employee> userManager, IDepartmentDataAccess departmentDataAccess)
        {
            _configuration = configuration;
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
            _departmentDataAccess = departmentDataAccess;
        }
        protected string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var secretKey = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretKey"));

            var jwt = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(5).ToUniversalTime(),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        protected string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        protected ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("SecretKey"))),
                ValidateLifetime = false
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }

        public async Task<AuthenticatedResponse?> Login(LoginDto loginDto)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(loginDto.Gmail);
                if (user is null)
                {
                    return null;
                }
                var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
                if (!result)
                {
                    return null;
                }

                var role = await _signInManager.UserManager.GetRolesAsync(user);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, role.ToString())
                };

                var accessToken = GenerateAccessToken(claims);
                var refreshToken = GenerateRefreshToken();
                //GenerateAccessToken(claims);
                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

                await _userManager.UpdateAsync(user);
                //_userContext.SaveChanges();
                return new AuthenticatedResponse
                {
                    Token = accessToken,
                    RefreshToken = refreshToken
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> Register(RegisterDto registerDto)
        {
            try
            {
                var isGmailExisted = await _userManager.FindByEmailAsync(registerDto.Email);
                if (isGmailExisted is not null)
                {
                    return "Tài khoản đã tồn tại";
                }

                var user = _mapper.Map<Employee>(registerDto);
                user.UserName = registerDto.Email;

                var result = await _userManager.CreateAsync(user, registerDto.Password);
                if (result.Succeeded)
                {
                    var roleName = await _departmentDataAccess.GetDepartmentByIdAsync(registerDto.DepartmentID);
                    await _signInManager.UserManager.AddToRoleAsync(user, roleName.Name);
                    //var roles = await
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return "Created success account";
                }
            }
            catch (Exception ex)
            {
                throw new NullReferenceException(ex.ToString());
            }
            return "Created failure account!";
        }
        public async Task<AuthenticatedResponse> RefreshToken(TokenDto tokenDto)
        {
            try
            {
                var principal = GetPrincipalFromExpiredToken(tokenDto.Token);
                var user = await _userManager.FindByNameAsync(principal.Identity.Name);

                if (user == null || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                {
                    return null;
                }

                var newAccessToken = GenerateAccessToken(principal.Claims);
                var newRefreshToken = GenerateRefreshToken();

                user.RefreshToken = newRefreshToken;
                user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

                await _userManager.UpdateAsync(user);

                return new AuthenticatedResponse
                {
                    Token = newAccessToken,
                    RefreshToken = newRefreshToken
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
