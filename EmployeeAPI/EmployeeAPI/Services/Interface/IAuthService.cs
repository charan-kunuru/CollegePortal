using EmployeeAPI.DTOs.Auth;
namespace EmployeeAPI.Services.Interface
{
    public interface IAuthService
    {
        Task<LoginResultDto> LoginAsync(LoginRequestDto dto);

    }
}
