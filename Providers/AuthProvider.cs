using backend.Models;
using backend.Models.ResponseModels;
using backend.Services;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace backend.Providers
{
    public interface IAuthProvider
    {
        Task<bool> Authenticate(string username, string password);
        Task<IEnumerable<Models.ResponseModels.EmployeeResponse>> GetEmployeesByLogin(string username);
    }

    public class AuthProvider : IAuthProvider
    {
        private readonly IEmployeeService _employeeService;
        private readonly PasswordHasher<Employee> _passwordHasher = new();

        public AuthProvider(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            var employees = await _employeeService.GetEmployees();
            var employee = employees.FirstOrDefault(e => e.LoginName == username);
            if (employee == null || string.IsNullOrEmpty(employee.PasswordHash)) return false;
            var result = _passwordHasher.VerifyHashedPassword(employee, employee.PasswordHash, password);
            return result == PasswordVerificationResult.Success;
        }

        public async Task<IEnumerable<EmployeeResponse>> GetEmployeesByLogin(string username)
        {
            var employees = await _employeeService.GetEmployees();
            return employees.Where(e => e.LoginName == username)
                .Select(e => new EmployeeResponse
                {
                    EmployeeId = e.Id,
                    Guid = e.Guid, 
                    EmployeeCode = e.EmployeeCode ?? string.Empty,
                    ShortName = e.ShortName ?? string.Empty,
                    FullName = e.FullName ?? string.Empty,
                    Designation = e.Designation ?? string.Empty,
                    HasSignedHRPolicy = false, // Map from your data source if available
                    HasSignedInfoSecPolicy = false, // Map from your data source if available
                    HasSignedRulesOfBehaviour = false, // Map from your data source if available
                    EmailId = e.EmailId ?? string.Empty,
                    ContactNumber = e.ContactNumber ?? string.Empty,
                    AlternateNumber = e.AlternateNumber ?? string.Empty
                });
        }
    }
}
