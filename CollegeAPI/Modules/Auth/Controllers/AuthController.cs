using CollegeAPI.Modules.Auth.Dtos;
using CollegeAPI.Modules.Auth.Services.Interface;
using CollegeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegeAPI.Modules.Auth.Controllers;

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
            return BadRequest("Invalid Username or Password");
        return Ok(new LoginResultDto
        {
            Token = token.Token,
            Role=token.Role

        });
    }
}
