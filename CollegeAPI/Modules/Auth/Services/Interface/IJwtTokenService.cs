using CollegeAPI.Modules.Users.Models;

namespace CollegeAPI.Modules.Auth.Services.Interface
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
    
}
