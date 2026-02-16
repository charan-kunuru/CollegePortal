using CollegeAPI.Modules.Auth.Dtos;
namespace CollegeAPI.Modules.Auth.Services.Interface
{
    public interface IAuthService
    {
        Task<LoginResultDto> LoginAsync(LoginRequestDto dto);

    }
}
