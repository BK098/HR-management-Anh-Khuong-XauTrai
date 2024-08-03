using HR_management.Domain.Entities;

namespace HR_management.Application.Services.DataAccess.Interfaces
{
    public interface IEmployeeDataAccess
    {
        Task<Employee> CreateEmployeeAsync(Employee employee);

        Employee UpdateEmployee(Employee employee);

        Task<IEnumerable<Employee>> GetAllEmployeesAsync();

        Task<Employee> GetEmployeeByIdAsync(Guid Id);

        bool DeleteEmployee(Employee employee);
    }
}
