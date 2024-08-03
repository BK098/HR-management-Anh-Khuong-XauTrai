using AutoMapper;
using HR_management.Application.Models.Employee;
using HR_management.Application.Services.DataAccess.Interfaces;
using HR_management.Domain.Entities;

namespace HR_management.Application.Services.ServicesImp
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeDataAccess _employeeDataAccess;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeDataAccess employeeDataAccess, IMapper mapper)
        {
            _employeeDataAccess = employeeDataAccess;
            _mapper = mapper;
        }

        public async Task<bool> CreateEmployee(CreateEmployeeDto employeeDto)
        {
            try
            {
                Employee employee = _mapper.Map<Employee>(employeeDto);
                await _employeeDataAccess.CreateEmployeeAsync(employee);
                return true;
            }
            catch (Exception ex)
            {
                
            }
            return false;
        }

        public async Task<bool> DeleteEmployee(Guid id)
        {
            try
            {
                Employee employee = await _employeeDataAccess.GetEmployeeByIdAsync(id);
                if (employee != null)
                {
                    _employeeDataAccess.DeleteEmployee(employee);
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public async Task<IEnumerable<EmployeeForView>> GetAllEmployee()
        {
            try
            {
                IEnumerable<Employee> employees = await _employeeDataAccess.GetAllEmployeesAsync();
                if (employees.Any())
                {
                    IEnumerable<EmployeeForView> res = _mapper.Map<IEnumerable<EmployeeForView>>(employees);
                    return res;
                }
            }
            catch (Exception ex)
            {
                
            }
            return null;
        }

        public async Task<EmployeeForView> GetEmployeeById(Guid id)
        {
            try
            {
                Employee employee = await _employeeDataAccess.GetEmployeeByIdAsync(id);
                if(employee != null)
                {
                    EmployeeForView res = _mapper.Map<EmployeeForView>(employee);
                    return res;
                }
            }
            catch (Exception ex)
            {
                
            }
            return null;
        }

        public async Task<bool> UpdateEmployee(Guid id, UpdateEmployeeDto employeeDto)
        {
            try
            {
                Employee employee = await _employeeDataAccess.GetEmployeeByIdAsync(id);
                if (employee != null)
                {
                    _employeeDataAccess.UpdateEmployee(employee);
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
