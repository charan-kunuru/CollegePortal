using CollegeAPI.Modules.Semesters.Models;
using CollegeAPI.Models;
namespace CollegeAPI.Modules.Semesters.Repositories.Interface
{
    public interface ISemesterRepository
    {
        Task<PagedResponse<Semester>> GetSemestersAsync(string? search, PagedRequest request);
        Task<bool> SemesterExistsAsync(int branchId, int semesterNo);
        Task<Semester?> GetByIdAsync(int id);
        Task<Semester> AddAsync(Semester semester);
        Task UpdateAsync(Semester semester);
        Task DeleteAsync(Semester semester);
    }
}