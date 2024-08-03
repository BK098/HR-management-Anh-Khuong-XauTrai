using HR_management.Application.Models.Department;
using HR_management.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService employeeService;

        public DepartmentsController(IDepartmentService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentDto employeeDto)
        {
            var res = await employeeService.CreateDepartment(employeeDto);
            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(Guid id, [FromBody] UpdateDepartmentDto employeeDto)
        {
            var res = await employeeService.UpdateDepartment(id, employeeDto);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(Guid id)
        {
            var res = await employeeService.DeleteDepartment(id);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(Guid id)
        {
            var res = await employeeService.GetDepartmentById(id);
            return Ok(res);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllDepartment()
        {
            var res = await employeeService.GetAllDepartments();
            return Ok(res);
        }
    }
}
