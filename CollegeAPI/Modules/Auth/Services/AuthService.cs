using CollegeAPI.Modules.Auth.Dtos;
using CollegeAPI.Modules.Auth.Services.Interface;
using CollegeAPI.Models;
using CollegeAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace CollegeAPI.Modules.Auth.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly IPasswordHasher _hasher;
    private readonly IJwtTokenService _jwt;

    public AuthService(AppDbContext context, IPasswordHasher hasher, IJwtTokenService jwt)
    {
        _context = context;
        _hasher = hasher;
        _jwt = jwt;
    }

    public async Task<LoginResultDto> LoginAsync(LoginRequestDto dto)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.UserName == dto.UserName);

        if (user == null || !user.IsActive)
            return null;
       

        if (!_hasher.Verify(dto.Password, user.PasswordHash))
            return null;
           

        var token= _jwt.GenerateToken(user);

        return new LoginResultDto
        {
            Token = token,
            Role = user.Role
        };


    }
}
