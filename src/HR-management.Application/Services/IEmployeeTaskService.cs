using HR_management.Application.Models.EmployeeTask;

namespace HR_management.Application.Services
{
    public interface IEmployeeTaskService
    {
        Task<bool> CreateEmployeeTask(CreateEmployeeTaskDto employeeTaskDto);
        Task<bool> UpdateEmployeeTask(Guid id, UpdateEmployeeTaskDto employeeTaskDto);
        Task<bool> DeleteEmployeeTask(Guid id);
        Task<EmployeeTaskForView> GetEmployeeTaskById(Guid id);
        Task<IEnumerable<EmployeeTaskForView>> GetAllEmployeesTask();
    }
}
