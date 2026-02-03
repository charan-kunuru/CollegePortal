using EmployeeAPI.DTOs.Auth;
using EmployeeAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers.AuthController;

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
    public async Task<IActionResult> Login(LoginRequestDto dto)
    {
        var token = await _authService.LoginAsync(dto);
        if (token == null)
            return Unauthorized(new { message = "Invalid Username or Password" });
        return Ok(new LoginResponseDto
        {
            Token = token.Token,
            Role=token.Role

        });
    }
}
