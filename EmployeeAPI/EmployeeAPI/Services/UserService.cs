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
        private readonly IUserRepository _UserRepo;
        private readonly IPasswordHasher _hasher;
        public UserService(IUserRepository UserRepo,IPasswordHasher hasher) 
        {
            _UserRepo= UserRepo;
            _hasher= hasher;
        }
       public async Task<User> CreateUserAsync(CreateUserDto dto)
        {
            if (await _UserRepo.GetUserByRollNoAsync(dto.RollNo)!=null)
            {
                throw new Exception("User with this roll number already exists.");
            }
            var user = new User
            {
                RollNo = dto.RollNo,
                PasswordHash = _hasher.Hash(dto.Password),
                Role = dto.Role,
                IsActive = true
            };
            await _UserRepo.AddUserAsync(user);
            await _UserRepo.SaveChangesAsync();
            return user;
        }
    }
}
