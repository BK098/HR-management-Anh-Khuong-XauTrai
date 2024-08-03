using HR_management.Application.Models.Timekeeping;
using HR_management.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimekeepingsController : ControllerBase
    {
        private readonly ITimekeepingService _timekeepingService;

        public TimekeepingsController(ITimekeepingService timekeepingService)
        {
            _timekeepingService = timekeepingService;
        }

        [HttpPost]
        public async Task<IActionResult> EmployeeTimekeeping([FromBody] EmployeeTimekeepingDto model)
        {
            var res = await _timekeepingService.EmployeeTimekeeping(model);
            return Ok(res);
        }
    }
}
