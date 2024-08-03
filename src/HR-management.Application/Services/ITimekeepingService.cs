using HR_management.Application.Models.Timekeeping;
using HR_management.Domain.Entities;

namespace HR_management.Application.Services
{
    public interface ITimekeepingService
    {
        Task<bool> CreateTimekeeping(CreateTimekeepingDto timeKeepingDto);
        Task<bool> UpdateTimekeeping(Guid id, UpdateTimekeepingDto timeKeepingDto);
        Task<bool> DeleteTimekeeping(Guid id);
        Task<TimekeepingForView> GetTimekeepingById(Guid id);
        Task<IEnumerable<TimekeepingForView>> GetAllTimekeepings();

        Task TimekeepingForEmployee(TimekeepingForEmployee model);
        Task<bool> EmployeeTimekeeping(EmployeeTimekeepingDto model);
    }
}
