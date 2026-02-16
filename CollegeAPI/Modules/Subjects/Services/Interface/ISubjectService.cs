using CollegeAPI.Modules.Auth.Services.Interface;
using CollegeAPI.Modules.Branches.Dtos;
using CollegeAPI.Modules.Subjects.Dtos;

namespace CollegeAPI.Modules.Subjects.Services.Interface
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectDto>> GetAllAsync();
        Task<SubjectDto?> GetByIdAsync(int id);
        Task<SubjectDto> CreateAsync(SubjectDto dto);
        Task<bool> UpdateAsync(int id, SubjectDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
