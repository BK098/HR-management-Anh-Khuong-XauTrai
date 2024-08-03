using HR_management.Application.Models.Auth;
using HR_management.Domain.Entities;

namespace HR_management.Application.Services.DataAccess.Interfaces
{
    public interface IAuthDataAccess
    {
        Task<Employee> Login(LoginDto loginDto);
        Task<Employee> Register(Employee employee);
    }
}
