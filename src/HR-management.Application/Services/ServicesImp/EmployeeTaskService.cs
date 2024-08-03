using AutoMapper;
using HR_management.Application.Models.EmployeeTask;
using HR_management.Application.Services.DataAccess.Interfaces;
using HR_management.Domain.Entities;

namespace HR_management.Application.Services.ServicesImp
{
    public class EmployeeTaskService : IEmployeeTaskService
    {
        private readonly IEmployeeTaskDataAccess _employeeTaskDataAccess;
        private readonly IMapper _mapper;

        public EmployeeTaskService(IEmployeeTaskDataAccess _employeeTaskDataAccess, IMapper mapper)
        {
            _employeeTaskDataAccess = _employeeTaskDataAccess;
            _mapper = mapper;
        }
        public async Task<bool> CreateEmployeeTask(CreateEmployeeTaskDto employeeTaskDto)
        {
            try
            {
                EmployeeTask employeeTask = _mapper.Map<EmployeeTask>(employeeTaskDto);
                await _employeeTaskDataAccess.CreateEmployeeTaskAsync(employeeTask);
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public async Task<bool> DeleteEmployeeTask(Guid id)
        {
            try
            {
                EmployeeTask employeeTask = await _employeeTaskDataAccess.GetEmployeeTaskByIdAsync(id);
                if (employeeTask != null)
                {
                    _employeeTaskDataAccess.DeleteEmployeeTask(employeeTask);
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public async Task<IEnumerable<EmployeeTaskForView>> GetAllEmployeesTask()
        {
            try
            {
                IEnumerable<EmployeeTask> employeesTask = await _employeeTaskDataAccess.GetAllEmployeeTasksAsync();
                if (employeesTask.Any())
                {
                    IEnumerable<EmployeeTaskForView> res = _mapper.Map<IEnumerable<EmployeeTaskForView>>(employeesTask);
                    return res;
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<EmployeeTaskForView> GetEmployeeTaskById(Guid id)
        {
            try
            {
                EmployeeTask employeeTask = await _employeeTaskDataAccess.GetEmployeeTaskByIdAsync(id);
                if (employeeTask != null)
                {
                    EmployeeTaskForView res = _mapper.Map<EmployeeTaskForView>(employeeTask);
                    return res;
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<bool> UpdateEmployeeTask(Guid id, UpdateEmployeeTaskDto employeeTaskDto)
        {
            try
            {
                EmployeeTask employeeTask = await _employeeTaskDataAccess.GetEmployeeTaskByIdAsync(id);
                if (employeeTask != null)
                {
                    _employeeTaskDataAccess.UpdateEmployeeTask(employeeTask);
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }
    }
}
