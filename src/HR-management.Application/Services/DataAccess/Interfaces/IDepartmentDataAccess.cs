using HR_management.Domain.Entities;

namespace HR_management.Application.Services.DataAccess.Interfaces
{
    public interface IDepartmentDataAccess
    {
        Task<Department> CreateDepartmentAsync(Department department);

        Department UpdateDepartment(Department department);

        Task<IEnumerable<Department>> GetAllDepartmentsAsync();

        Task<Department> GetDepartmentByIdAsync(Guid Id);

        bool DeleteDepartment(Department department);
    }
}
