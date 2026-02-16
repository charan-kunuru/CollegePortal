using CollegeAPI.Modules.Users.Models;
using CollegeAPI.Models;    
namespace CollegeAPI.Modules.Users.Repositories.Interface
{
    public interface IUserRepository
    {

        Task<PagedResponse<User>> GetUsersAsync(string? search, PagedRequest request);
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByUserNameAsync(string userName);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}
