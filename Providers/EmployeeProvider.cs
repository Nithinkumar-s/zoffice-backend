using backend.Models; 

namespace backend.Providers
{
    public interface IEmployeeProvider
    {
        Employee ManipulateEmployee(Employee employee);
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> AddEmployee(Employee employee, string password);
        Task<Employee?> UpdateEmployee(Employee employee, string? password = null);
    }

    public class EmployeeProvider : IEmployeeProvider
    {
        private readonly Services.IEmployeeService _employeeService;
        public EmployeeProvider(Services.IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public Employee ManipulateEmployee(Employee employee)
        {
            // Add manipulation logic if needed
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _employeeService.GetEmployees();
        }

        public async Task<Employee> AddEmployee(Employee employee, string password)
        {
            var manipulated = ManipulateEmployee(employee);
            return await _employeeService.AddEmployee(manipulated, password);
        }

        public async Task<Employee?> UpdateEmployee(Employee employee, string? password = null)
        {
            var manipulated = ManipulateEmployee(employee);
            return await _employeeService.UpdateEmployee(manipulated, password);
        }
    }
}
