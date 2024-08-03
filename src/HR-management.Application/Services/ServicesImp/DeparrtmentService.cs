using AutoMapper;
using HR_management.Application.Models.Department;
using HR_management.Application.Services.DataAccess.Interfaces;
using HR_management.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace HR_management.Application.Services.ServicesImp
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentDataAccess _departmentDataAccess;
        private readonly IMapper _mapper;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<Employee> _userManager;

        public DepartmentService(
            IDepartmentDataAccess departmentDataAccess,
            IMapper mapper,
            RoleManager<Role> roleManager,
            UserManager<Employee> userManager)
        {
            _departmentDataAccess = departmentDataAccess;
            _mapper = mapper;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<bool> CreateDepartment(CreateDepartmentDto departmentDto)
        {
            try
            {
                Department department = _mapper.Map<Department>(departmentDto);
                var role = new Role()
                {
                    Name = departmentDto.Name,
                    NormalizedName = department.Name.Normalize()
                };
                await _roleManager.CreateAsync(role);

                await _departmentDataAccess.CreateDepartmentAsync(department);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        public async Task<bool> DeleteDepartment(Guid id)
        {
            try
            {
                Department department = await _departmentDataAccess.GetDepartmentByIdAsync(id);
                if (department != null)
                {
                    _departmentDataAccess.DeleteDepartment(department);
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public async Task<IEnumerable<DepartmentForView>> GetAllDepartments()
        {
            try
            {
                IEnumerable<Department> departments = await _departmentDataAccess.GetAllDepartmentsAsync();
                if (departments.Any())
                {
                    IEnumerable<DepartmentForView> res = _mapper.Map<IEnumerable<DepartmentForView>>(departments);
                    return res;
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<DepartmentForView> GetDepartmentById(Guid id)
        {
            try
            {
                Department department = await _departmentDataAccess.GetDepartmentByIdAsync(id);
                if (department != null)
                {
                    DepartmentForView res = _mapper.Map<DepartmentForView>(department);
                    return res;
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<bool> UpdateDepartment(Guid id, UpdateDepartmentDto departmentDto)
        {
            try
            {
                Department department = await _departmentDataAccess.GetDepartmentByIdAsync(id);
                if (department != null)
                {
                    var getRoleUpdate = await _roleManager.FindByNameAsync(department.Name);
                    getRoleUpdate.Name = departmentDto.Name;
                    getRoleUpdate.NormalizedName = departmentDto.Name.Normalize();
                    await _roleManager.UpdateAsync(getRoleUpdate);

                    _departmentDataAccess.UpdateDepartment(department);

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
