using CollegeAPI.Models;
using CollegeAPI.Modules.Users.Dtos;
using CollegeAPI.Modules.Users.Repositories.Interface;
using CollegeAPI.Modules.Users.Models;
namespace CollegeAPI.Modules.Users.Services.Interface
{
    public interface IUserService
    {
        Task<PagedResponse<UserResponseDto>> GetUsersAsync(string? search, PagedRequest request);

        Task<UserResponseDto?> GetUserByIdAsync(int id);
        Task CreateUserAsync(CreateUserDto dto);
        Task UpdateUserAsync(int id, UserResponseDto dto);
        Task DeleteUserAsync(int id);

    }
}
