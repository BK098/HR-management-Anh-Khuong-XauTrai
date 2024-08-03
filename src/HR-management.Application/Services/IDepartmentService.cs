using HR_management.Application.Models.Department;

namespace HR_management.Application.Services
{
    public interface IDepartmentService
    {
        Task<bool> CreateDepartment(CreateDepartmentDto departmentDto);
        Task<bool> UpdateDepartment(Guid id, UpdateDepartmentDto departmentDto);
        Task<bool> DeleteDepartment(Guid id);
        Task<DepartmentForView> GetDepartmentById(Guid id);
        Task<IEnumerable<DepartmentForView>> GetAllDepartments();
    }
}
