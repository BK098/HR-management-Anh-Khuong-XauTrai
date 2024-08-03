using HR_management.Application.Models.Timekeeping;
using HR_management.Application.Services.DataAccess.Interfaces;
using HR_management.Domain.Entities;
using HR_management.Domain.Enums;

namespace HR_management.Application.Services.ServicesImp
{
    public class RequestFormService : IRequestFormService
    {
        private readonly IRequestFormDataAccess _requestFormDataAccess;

        public RequestFormService(IRequestFormDataAccess requestFormDataAccess)
        {
            _requestFormDataAccess = requestFormDataAccess;
        }

        public async Task<bool> EmployeeRequestUpdateTimekeeping(EmployeeRequestUpdateTimekeepingDto model)
        {
            try
            {
                RequestForm form = new RequestForm();
                form.EmployeeId = model.EmployeeId;
                form.CreatedDate = model.Day;
                form.CheckIn = model.CheckIn;
                form.CheckOut = model.CheckOut;
                form.Reason = model.Reason;
                await _requestFormDataAccess.CreateRequestFormAsync(form);

                return true;
            }
            catch (Exception)
            {

            }
            return false;
        }

        public async Task<bool> HRAcceptedRequestForm(Guid id)
        {
            try
            {
                //findbyid
                RequestForm form = new RequestForm();
                if (form != null)
                {
                    form.Status = RequestFormStatus.Accepted;
                    //update form
                    //update timekeeping employee
                    return true;
                }
            }
            catch (Exception)
            {

            }
            return false;
        }

        public async Task<bool> HRRejectedRequestForm(Guid id)
        {
            try
            {
                //findbyid
                RequestForm form = new RequestForm();
                if (form != null)
                {
                    form.Status = RequestFormStatus.Rejected;
                    //update form
                    return true;
                }
            }
            catch (Exception)
            {

            }
            return false;
        }
    }
}
