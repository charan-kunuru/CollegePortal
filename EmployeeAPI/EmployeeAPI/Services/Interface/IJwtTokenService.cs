using EmployeeAPI.Models;

namespace EmployeeAPI.Services.Interface
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
    
}
