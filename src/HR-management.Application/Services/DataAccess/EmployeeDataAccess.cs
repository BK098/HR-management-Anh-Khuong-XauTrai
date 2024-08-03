using HR_management.Application.Services.DataAccess.Interfaces;
using HR_management.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using HR_management.Domain;

namespace HR_management.Application.Services.DataAccess
{
    public class EmployeeDataAccess : IEmployeeDataAccess
    {
        private readonly ApplicationDbContext _context;

        public EmployeeDataAccess(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public bool DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid Id)
        {
            return await _context.Employees.SingleOrDefaultAsync(e => e.Id == Id);
        }

        public Employee UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return employee;
        }
    }
}
