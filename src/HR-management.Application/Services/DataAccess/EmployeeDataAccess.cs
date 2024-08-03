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

        public async Task<Employee> CreateEmployeeAsync(Employee userDto)
        {
            await _context.Users.AddAsync(userDto);
            await _context.SaveChangesAsync();
            return userDto;
        }

        public bool DeleteEmployee(Employee userDto)
        {
            _context.Users.Remove(userDto);
            _context.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid Id)
        {
            return await _context.Users.SingleOrDefaultAsync(e => e.Id == Id);
        }

        public Employee UpdateEmployee(Employee userDto)
        {
            _context.Users.Update(userDto);
            _context.SaveChanges();
            return userDto;
        }
    }
}
