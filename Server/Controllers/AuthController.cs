using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SMI.Server.Services;
using Infrastructure.Models;
using System.Threading.Tasks;

namespace SMI.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var success = await _authService.LoginAsync(loginRequest);

            if (success)
                return Ok(new { message = "Inicio de sesión exitoso" });
            else
                return Unauthorized(new { message = "Correo o clave inválidos, o usuario inactivo" });
        }
    }
}
