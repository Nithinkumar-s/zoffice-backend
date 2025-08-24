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
        private readonly IEmployeeProvider _employeeProvider;
        public EmployeesController(IEmployeeProvider employeeProvider)
        {
            _employeeProvider = employeeProvider;
        }

        [HttpGet]

        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeProvider.GetEmployees();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee, [FromQuery] string password)
        {
            var result = await _employeeProvider.AddEmployee(employee, password);
            return CreatedAtAction(nameof(GetEmployees), new { id = result.Id }, result);
        }

        [HttpPost("update/{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee employee, [FromQuery] string? password = null)
        {
            employee.Id = id;
            var result = await _employeeProvider.UpdateEmployee(employee, password);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
