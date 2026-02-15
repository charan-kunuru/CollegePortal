using EmployeeAPI.DTOs.Subject;

namespace EmployeeAPI.Services.Interface
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
