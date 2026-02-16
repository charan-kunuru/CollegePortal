using Microsoft.EntityFrameworkCore;
using CollegeAPI.Models;
using CollegeAPI.Modules.Users.Models;
using CollegeAPI.Modules.Users.Repositories.Interface;
using CollegeAPI.Data;
namespace CollegeAPI.Modules.Users.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository (AppDbContext Context) 
        {
              _context= Context;
        }


        public async Task<PagedResponse<User>> GetUsersAsync(string? search, PagedRequest request)
        {
            var query = _context.Users.AsQueryable();

            // Search by Username
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(u =>
                    u.UserName.Contains(search));
            }

            var totalRecords = await query.CountAsync();

            var users = await query
                .OrderBy(u => u.Id)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            return new PagedResponse<User>(
                users,
                totalRecords,
                request.PageNumber,
                request.PageSize
            );
        }
        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User?> GetUserByUserNameAsync(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
