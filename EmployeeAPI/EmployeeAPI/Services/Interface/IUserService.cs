
using EmployeeAPI.DTOs.Admin;
using EmployeeAPI.DTOs.Branch;
using EmployeeAPI.Models;
namespace EmployeeAPI.Services.Interface
{
    public interface IUserService
    {
        Task<List<UserResponseDto>> GetAllUsersAsync();
        Task<UserResponseDto?> GetUserByIdAsync(int id);
        Task CreateUserAsync(CreateUserDto dto);
        Task UpdateUserAsync(int id, UserResponseDto dto);
        Task DeleteUserAsync(int id);

    }
}
