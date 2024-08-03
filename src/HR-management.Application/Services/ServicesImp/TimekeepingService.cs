using AutoMapper;
using HR_management.Application.Models.Timekeeping;
using HR_management.Application.Services.DataAccess.Interfaces;
using HR_management.Domain.Entities;

namespace HR_management.Application.Services.ServicesImp
{
    public class TimekeepingService : ITimekeepingService
    {
        private readonly ITimekeepingDataAccess _timeKeepingDataAccess;
        private readonly IMapper _mapper;

        public TimekeepingService(ITimekeepingDataAccess timeKeepingDataAccess, IMapper mapper)
        {
            _timeKeepingDataAccess = timeKeepingDataAccess;
            _mapper = mapper;
        }
        public async Task<bool> CreateTimekeeping(CreateTimekeepingDto timekeepingDto)
        {
            try
            {
                Timekeeping timekeeping = _mapper.Map<Timekeeping>(timekeepingDto);
                await _timeKeepingDataAccess.CreateTimekeepingAsync(timekeeping);
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public async Task<bool> DeleteTimekeeping(Guid id)
        {
            try
            {
                Timekeeping timekeeping = await _timeKeepingDataAccess.GetTimekeepingByIdAsync(id);
                if (timekeeping != null)
                {
                    _timeKeepingDataAccess.DeleteTimekeeping(timekeeping);
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public async Task<IEnumerable<TimekeepingForView>> GetAllTimekeepings()
        {
            try
            {
                IEnumerable<Timekeeping> timekeepings = await _timeKeepingDataAccess.GetAllTimekeepingsAsync();
                if (timekeepings.Any())
                {
                    IEnumerable<TimekeepingForView> res = _mapper.Map<IEnumerable<TimekeepingForView>>(timekeepings);
                    return res;
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<TimekeepingForView> GetTimekeepingById(Guid id)
        {
            try
            {
                Timekeeping timekeeping = await _timeKeepingDataAccess.GetTimekeepingByIdAsync(id);
                if (timekeeping != null)
                {
                    TimekeepingForView res = _mapper.Map<TimekeepingForView>(timekeeping);
                    return res;
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task TimekeepingForEmployee(TimekeepingForEmployee model)
        {
            try
            {
                //Timekeeping timekeeping = await _timeKeepingDataAccess.GetTimekeepingByEmployeeIdAndDateSpecific(model.EmployeeId, DateTimeOffset.UtcNow);
                //if(timekeeping != null && timekeeping.CheckIn == null && timekeeping.CreatedDate == DateTimeOffset.UtcNow)
                //{
                //    //chấm công buổi sáng
                //}
                //else if(timekeeping != null && timekeeping.CheckOut == null && timekeeping.CreatedDate == DateTimeOffset.UtcNow)
                //{
                //    //chấm công buổi chiều
                //}

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateTimekeeping(Guid id, UpdateTimekeepingDto timekeepingDto)
        {
            try
            {
                Timekeeping timekeeping = await _timeKeepingDataAccess.GetTimekeepingByIdAsync(id);
                if (timekeeping != null)
                {
                    _timeKeepingDataAccess.UpdateTimekeeping(timekeeping);
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public async Task<bool> EmployeeTimekeeping(EmployeeTimekeepingDto model)
        {
            try
            {
                Timekeeping time = new Timekeeping();
                DateTime now = DateTime.Now;
                string formattedDate = now.ToString("MM/dd");
                int daysInMonth = DateTime.DaysInMonth(now.Year, now.Month);
                time.Time = formattedDate;
                time.Day = daysInMonth;

                Guid? id = await _timeKeepingDataAccess.CheckTimekeepingExistsAsync(time);
                if(id is null)
                {
                    id = await _timeKeepingDataAccess.CreateTimekeepingAsync(time);
                }

                EmployeeTimekeeping timekeeping = await _timeKeepingDataAccess.GetTimekeepingByEmployeeIdAndDateSpecific(model.EmployeeId, model.CreatedDate);
                if(timekeeping != null && timekeeping.CheckIn == null && timekeeping.CreatedDate == DateTimeOffset.UtcNow)
                {
                    //chấm công buổi sáng
                    EmployeeTimekeeping employeeTimekeeping = new EmployeeTimekeeping();
                    employeeTimekeeping.EmployeeId = model.EmployeeId;
                    employeeTimekeeping.CheckIn = model.Time;
                    employeeTimekeeping.CreatedDate = DateTimeOffset.UtcNow;
                    employeeTimekeeping.TimekeepingId = id.Value;

                    await _timeKeepingDataAccess.CreateEmployeeTimekeepingAsync(employeeTimekeeping);

                }
                else if (timekeeping != null && timekeeping.CheckOut == null && timekeeping.CreatedDate == DateTimeOffset.UtcNow)
                {
                    //chấm công buổi chiều
                    EmployeeTimekeeping employeeTimekeeping = new EmployeeTimekeeping();
                    employeeTimekeeping.EmployeeId = model.EmployeeId;
                    employeeTimekeeping.CheckOut = model.Time;
                    employeeTimekeeping.WorkHours = employeeTimekeeping.CheckOut - employeeTimekeeping.CheckIn;
                    employeeTimekeeping.CreatedDate = DateTimeOffset.UtcNow;
                    employeeTimekeeping.TimekeepingId = id.Value;

                    await _timeKeepingDataAccess.CreateEmployeeTimekeepingAsync(employeeTimekeeping);
                }
                return true;
            }
            catch (Exception)
            {
                
            }
            return false;
        }
    }
}
