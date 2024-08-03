using HR_management.Domain.Entities;

namespace HR_management.Application.Services.DataAccess.Interfaces
{
    public interface IEmployeeTaskDataAccess
    {
        Task<EmployeeTask> CreateEmployeeTaskAsync(EmployeeTask task);

        EmployeeTask UpdateEmployeeTask(EmployeeTask task);

        Task<IEnumerable<EmployeeTask>> GetAllEmployeeTasksAsync();

        Task<EmployeeTask> GetEmployeeTaskByIdAsync(Guid Id);

        bool DeleteEmployeeTask(EmployeeTask task);
    }
}
