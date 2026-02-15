using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Models;
using EmployeeAPI.Services.Interface;
using EmployeeAPI.Repositories.Interface;
using System.Threading.Tasks;
using EmployeeAPI.DTOs;
using EmployeeAPI.DTOs.Auth;
using EmployeeAPI.DTOs.Admin;

namespace EmployeeAPI.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IPasswordHasher _hasher;
        public UserService(IUserRepository UserRepo,IPasswordHasher hasher) 
        {
            _repo= UserRepo;
            _hasher= hasher;
        }


       public async Task<List<UserResponseDto>> GetAllUsersAsync()
    {
        var users = await _repo.GetAllUsersAsync();

        return users.Select(u => new UserResponseDto
        {
            Id = u.Id,
            UserName = u.UserName,
            Role = u.Role
        }).ToList();
    }

        public async Task<UserResponseDto?> GetUserByIdAsync(int id)
        {
            var user = await _repo.GetUserByIdAsync(id);
            if (user == null) return null;

            return new UserResponseDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Role = user.Role
            };
        }

        public async Task CreateUserAsync(CreateUserDto dto)
        {
            var existing = await _repo.GetUserByUserNameAsync(dto.UserName);
            if (existing != null) return;

            var user = new User
            {
                UserName = dto.UserName,
                PasswordHash = _hasher.Hash(dto.Password),
                Role = dto.Role,
                IsActive = true
            };

            await _repo.AddAsync(user);
        }

        public async Task UpdateUserAsync(int id, UserResponseDto dto)
        {
            var user = await _repo.GetUserByIdAsync(id);
            if (user == null) return;

            user.Role = dto.Role;
            await _repo.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _repo.GetUserByIdAsync(id);
            if (user == null) return;

            await _repo.DeleteAsync(user);
        }

    }
}
