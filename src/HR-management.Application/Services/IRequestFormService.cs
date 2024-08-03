using HR_management.Application.Models.Timekeeping;

namespace HR_management.Application.Services
{
    public interface IRequestFormService
    {
        Task<bool> EmployeeRequestUpdateTimekeeping(EmployeeRequestUpdateTimekeepingDto model); 
        Task<bool> HRAcceptedRequestForm(Guid id); 
        Task<bool> HRRejectedRequestForm(Guid id);
    }
}
