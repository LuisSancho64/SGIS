using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SMI.Shared.DTOs;

namespace SMI.Server.Controllers;

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
    public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
    {
        var result = await _authService.LoginAsync(request);
        if (result == null)
            return Unauthorized("Credenciales inválidas");

        return Ok(result);
    }
}
