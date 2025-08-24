using Microsoft.AspNetCore.Mvc;
using backend.Models.RequestModels;
using System.Linq;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly Providers.IAuthProvider _authProvider;
        public AuthController(Providers.IAuthProvider authProvider)
        {
            _authProvider = authProvider;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Models.RequestModels.LoginRequest request)
        {
            var employees = await _authProvider.GetEmployeesByLogin(request.Username);
            var employee = employees.FirstOrDefault();
            var isAuthenticated = await _authProvider.Authenticate(request.Username, request.Password);
            if (!isAuthenticated || employee == null) return Unauthorized();
            return Ok(employee);
        }
    }
 
  
}
