using CollegeAPI.Modules.Semesters.Dtos;
using CollegeAPI.Modules.Semesters.Repositories.Interface;
using CollegeAPI.Models;
namespace CollegeAPI.Modules.Semesters.Services.Interface
{
    public interface ISemesterService
    {
        Task<PagedResponse<SemesterResponseDto>> GetSemestersAsync(string? search, PagedRequest request);
        Task<SemesterResponseDto?> GetByIdAsync(int id);
 
        Task<bool> CreateSemesterAsync(SemesterCreateDto dto);
        Task UpdateAsync(int id, SemesterCreateDto dto);
        Task DeleteAsync(int id);
    }
}
