using HR_management.Application.Services.DataAccess.Interfaces;
using HR_management.Domain;
using HR_management.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR_management.Application.Services.DataAccess
{
    public class EmployeeTaskDataAccess : IEmployeeTaskDataAccess
    {
        private readonly ApplicationDbContext _context;

        public EmployeeTaskDataAccess(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeeTask> CreateEmployeeTaskAsync(EmployeeTask employee)
        {
            await _context.EmployeeTasks.AddAsync(employee);
            return employee;
        }

        public bool DeleteEmployeeTask(EmployeeTask employee)
        {
            _context.EmployeeTasks.Remove(employee);
            return true;
        }

        public async Task<IEnumerable<EmployeeTask>> GetAllEmployeeTasksAsync()
        {
            return await _context.EmployeeTasks.ToListAsync();
        }

        public async Task<EmployeeTask> GetEmployeeTaskByIdAsync(Guid Id)
        {
            return await _context.EmployeeTasks.SingleOrDefaultAsync(e => e.Id == Id);
        }

        public EmployeeTask UpdateEmployeeTask(EmployeeTask employee)
        {
            _context.EmployeeTasks.Update(employee);
            return employee;
        }
    }
}
