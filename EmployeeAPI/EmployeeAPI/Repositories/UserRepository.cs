using EmployeeAPI.Data;
using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Models;   
using EmployeeAPI.Repositories.Interface;
using System.Threading.Tasks;
namespace EmployeeAPI.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext _Context;
        public UserRepository (AppDbContext Context) 
        {
              _Context= Context;
        }
        public async Task<User?> GetUserByRollNoAsync(string rollNo)
        {
            return await _Context.Users.FirstOrDefaultAsync(u => u.RollNo == rollNo);
        }
        public async Task AddUserAsync(User user)
        {
            await _Context.Users.AddAsync(user);
        }
        public async Task SaveChangesAsync()
        {
            await _Context.SaveChangesAsync();
        }
    }
}
