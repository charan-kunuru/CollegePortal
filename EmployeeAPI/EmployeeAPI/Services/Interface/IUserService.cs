
using EmployeeAPI.Models;
using EmployeeAPI.DTOs.Admin;
namespace EmployeeAPI.Services.Interface
{
    public interface IUserService
    {
       Task<User> CreateUserAsync(CreateUserDto dto);
    }
}
