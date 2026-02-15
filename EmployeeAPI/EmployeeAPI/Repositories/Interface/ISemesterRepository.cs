using EmployeeAPI.Models;
namespace EmployeeAPI.Repositories.Interface
{
    public interface ISemesterRepository
    {
        Task<IEnumerable<Semester>> GetAllAsync();
        Task<Semester?> GetByIdAsync(int id);
        Task<Semester> AddAsync(Semester semester);
        Task UpdateAsync(Semester semester);
        Task DeleteAsync(Semester semester);
    }
}