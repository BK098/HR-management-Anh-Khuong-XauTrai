using AutoMapper;
using HR_management.Application.Models.Auth;
using HR_management.Application.Services.DataAccess.Interfaces;
using HR_management.Domain.Entities;
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
        private readonly IAuthDataAccess _authDataAccess;
        private readonly IMapper _mapper;
        public AuthService(IConfiguration configuration, IAuthDataAccess authDataAccess, IMapper mapper)
        {
            _configuration = configuration;
            _authDataAccess = authDataAccess;
            _mapper = mapper;
        }
        protected string GenerateAccessToken(IEnumerable<Claim> claims, DateTime expireAt)
        {
            var secretKey = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretKey"));

            var jwt = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expireAt,
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
                var hasEmployee = await _authDataAccess.Login(loginDto);
                if (hasEmployee is null)
                    return null;


                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginDto.Username),
                    new Claim(ClaimTypes.Role, "Manager")
                };
                var accessToken = "";
                //GenerateAccessToken(claims);
                var refreshToken = GenerateRefreshToken();
                //user.RefreshToken = refreshToken;
                //user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
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
                Employee employee = _mapper.Map<Employee>(registerDto);
                Employee createdEmployee = await _authDataAccess.Register(employee);
                if (createdEmployee != null)
                {
                    var accessToken = "";
                    //GenerateAccessToken(claims);
                    var refreshToken = GenerateRefreshToken();
                    //user.RefreshToken = refreshToken;
                    //user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
                    //_userContext.SaveChanges();
                    return "Created success account";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return "Created failure account!";
        }
    }
}
