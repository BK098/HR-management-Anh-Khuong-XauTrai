using HR_management.Application.Models.Employee;
using HR_management.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace HR_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto employeeDto)
        {
            var res = await employeeService.CreateEmployee(employeeDto);
            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] UpdateEmployeeDto employeeDto)
        {
            var res = await employeeService.UpdateEmployee(id, employeeDto);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var res = await employeeService.DeleteEmployee(id);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            var res = await employeeService.GetEmployeeById(id);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var res = await employeeService.GetAllEmployee();
            return Ok(res);
        }
    }
}
