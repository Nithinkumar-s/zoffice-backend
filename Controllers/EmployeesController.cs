using backend.Models;
using backend.Services;
using backend.Providers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeProvider _employeeProvider;
        public EmployeesController(IEmployeeService employeeService, IEmployeeProvider employeeProvider)
        {
            _employeeService = employeeService;
            _employeeProvider = employeeProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            var manipulated = _employeeProvider.ManipulateEmployee(employee);
            var result = await _employeeService.AddEmployeeAsync(manipulated);
            return CreatedAtAction(nameof(GetEmployees), new { id = result.Id }, result);
        }
    }
}
