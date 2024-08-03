using HR_management.Domain.Entities;

namespace HR_management.Application.Services.DataAccess.Interfaces
{
    public interface ITimekeepingDataAccess
    {
        Task<Guid> CreateTimekeepingAsync(Timekeeping timekeeping);
        Task<Guid?> CheckTimekeepingExistsAsync(Timekeeping timekeeping);
        Task<bool> CreateEmployeeTimekeepingAsync(EmployeeTimekeeping employeeTimekeeping);

        Timekeeping UpdateTimekeeping(Timekeeping timekeeping);

        Task<IEnumerable<Timekeeping>> GetAllTimekeepingsAsync();

        Task<Timekeeping> GetTimekeepingByIdAsync(Guid Id);

        bool DeleteTimekeeping(Timekeeping timekeeping);
        Task<EmployeeTimekeeping> GetTimekeepingByEmployeeIdAndDateSpecific(Guid employeeId, DateTimeOffset Date);
    }
}
