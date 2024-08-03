using HR_management.Application.Models.Auth;

namespace HR_management.Application.Services.DataAccess
{
    public class AuthDataAccess : IAuthService
    {
        public Task<string> Login(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }

        public Task<string> Register(RegisterDto registerDto)
        {
            throw new NotImplementedException();
        }

        Task<AuthenticatedResponse?> IAuthService.Login(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }
    }
}
