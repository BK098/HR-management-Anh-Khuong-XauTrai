using HR_management.Application.Services.DataAccess.Interfaces;
using HR_management.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using HR_management.Domain;

namespace HR_management.Application.Services.DataAccess
{
    public class TimekeepingDataAccess : ITimekeepingDataAccess
    {
        private readonly ApplicationDbContext _context;

        public TimekeepingDataAccess(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Guid?> CheckTimekeepingExistsAsync(Timekeeping timekeeping)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateEmployeeTimekeepingAsync(EmployeeTimekeeping employeeTimekeeping)
        {
            await _context.EmployeeTimekeepings.AddAsync(employeeTimekeeping);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Guid> CreateTimekeepingAsync(Timekeeping employee)
        {
            await _context.Timekeepings.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee.Id;
        }

        public bool DeleteTimekeeping(Timekeeping employee)
        {
            _context.Timekeepings.Remove(employee);
            _context.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<Timekeeping>> GetAllTimekeepingsAsync()
        {
            return await _context.Timekeepings.ToListAsync();
        }

        public EmployeeTimekeeping GetTimeKeepingByEmployeeIdAndDateSpecific(Guid employeeId, DateTimeOffset Date)
        {
            throw new NotImplementedException();
        }

        public async Task<Timekeeping> GetTimekeepingByIdAsync(Guid Id)
        {
            return await _context.Timekeepings.SingleOrDefaultAsync(e => e.Id == Id);
        }

        public Timekeeping UpdateTimekeeping(Timekeeping employee)
        {
            _context.Timekeepings.Update(employee);
            _context.SaveChanges();
            return employee;
        }

        Task<Timekeeping> ITimekeepingDataAccess.GetTimekeepingByEmployeeIdAndDateSpecific(Guid employeeId, DateTimeOffset Date)
        {
            throw new NotImplementedException();
        }
    }
}
