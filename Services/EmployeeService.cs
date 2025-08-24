using backend.Models;
using Microsoft.EntityFrameworkCore;
using backend.Data; 

namespace backend.Services
{
    public interface IEmployeeService
    {
    Task<IEnumerable<Employee>> GetEmployees();
    Task<Employee?> GetEmployee(int id);
    Task<Employee> AddEmployee(Employee employee, string plainPassword);
    Task<Employee?> UpdateEmployee(Employee employee, string? plainPassword = null);
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;
        private readonly Microsoft.AspNetCore.Identity.PasswordHasher<Employee> _passwordHasher = new();

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

    public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

    public async Task<Employee?> GetEmployee(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

    public async Task<Employee> AddEmployee(Employee employee, string plainPassword)
        {
            employee.PasswordHash = _passwordHasher.HashPassword(employee, plainPassword);
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

    public async Task<Employee?> UpdateEmployee(Employee employee, string? plainPassword = null)
        {
            var existing = await _context.Employees.FindAsync(employee.Id);
            if (existing == null) return null;

            // Update fields
            existing.FullName = employee.FullName;
            existing.ShortName = employee.ShortName;
            existing.LoginName = employee.LoginName;
            existing.Designation = employee.Designation;
            existing.EmployeeCode = employee.EmployeeCode;
            existing.PFAccountNo = employee.PFAccountNo;
            existing.EmailId = employee.EmailId;
            existing.ContactNumber = employee.ContactNumber;
            existing.Address = employee.Address;
            existing.AlternateNumber = employee.AlternateNumber;
            existing.Location = employee.Location;
            existing.ReportTo = employee.ReportTo;

            if (!string.IsNullOrEmpty(plainPassword))
            {
                existing.PasswordHash = _passwordHasher.HashPassword(existing, plainPassword);
            }

            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
