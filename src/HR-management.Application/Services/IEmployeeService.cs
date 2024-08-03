using HR_management.Application.Models.Employee;

namespace HR_management.Application.Services
{
    public interface IEmployeeService
    {
        Task<bool> CreateEmployee(CreateEmployeeDto employeeDto);
        Task<bool> UpdateEmployee(Guid id, UpdateEmployeeDto employeeDto);
        Task<bool> DeleteEmployee(Guid id);
        Task<EmployeeForView> GetEmployeeById(Guid id);
        Task<IEnumerable<EmployeeForView>> GetAllEmployee();
    }
}
