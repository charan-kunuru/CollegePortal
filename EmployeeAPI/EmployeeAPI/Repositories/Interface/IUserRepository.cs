using EmployeeAPI.Models;
namespace EmployeeAPI.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User?> GetUserByRollNoAsync(string rollNo);
        Task AddUserAsync(User user);
        Task SaveChangesAsync();
    }
}
