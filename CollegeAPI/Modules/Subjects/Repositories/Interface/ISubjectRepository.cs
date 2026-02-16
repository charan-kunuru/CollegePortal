using CollegeAPI.Modules.Subjects.Models;
using CollegeAPI.Models;

namespace CollegeAPI.Modules.Subjects.Repositories.Interface
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetAllAsync();
        Task<Subject?> GetByIdAsync(int id);
        Task<Subject> AddAsync(Subject subject);
        Task UpdateAsync(Subject subject);
        Task DeleteAsync(Subject subject);
    }
}
