using CollegeAPI.Modules.Auth.Services.Interface;
using CollegeAPI.Modules.Users.Dtos;
using CollegeAPI.Modules.Users.Repositories.Interface;
using CollegeAPI.Modules.Users.Services.Interface;
using CollegeAPI.Models;
using CollegeAPI.Modules.Users.Models;

using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace CollegeAPI.Modules.Users.Services
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
        public async Task<PagedResponse<UserResponseDto>> GetUsersAsync(string? search, PagedRequest request)
        {
            var pagedUsers = await _repo.GetUsersAsync(search, request);

            var userDtos = pagedUsers.Data.Select(u => new UserResponseDto
            {
                Id = u.Id,
                UserName = u.UserName,
                Role = u.Role
            });

            return new PagedResponse<UserResponseDto>(
                userDtos,
                pagedUsers.TotalRecords,
                pagedUsers.PageNumber,
                pagedUsers.PageSize
            );
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
