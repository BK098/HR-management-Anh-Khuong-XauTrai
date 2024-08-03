using HR_management.Domain.Entities;

namespace HR_management.Application.Services.DataAccess.Interfaces
{
    public interface IRequestFormDataAccess
    {
        Task<bool> CreateRequestFormAsync(RequestForm form);
        Task<bool> HRChangeStatusRequestForm(RequestForm form);
    }
}
