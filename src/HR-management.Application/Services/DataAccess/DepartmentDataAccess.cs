using HR_management.Application.Services.DataAccess.Interfaces;
using HR_management.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using HR_management.Domain;

namespace HR_management.Application.Services.DataAccess
{
    public class DepartmentDataAccess : IDepartmentDataAccess
    {
        private readonly ApplicationDbContext _context;

        public DepartmentDataAccess(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Department> CreateDepartmentAsync(Department department)
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public bool DeleteDepartment(Department department)
        {
            _context.Departments.Remove(department);
            _context.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentByIdAsync(Guid Id)
        {
            return await _context.Departments.SingleOrDefaultAsync(e => e.Id == Id);
        }

        public Department UpdateDepartment(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
            return department;
        }
    }
}
