using EmployeeAPI.DTOs.Semester;
using EmployeeAPI.Models;
namespace EmployeeAPI.Services.Interface
{
    public interface ISemesterService
    {
        Task<IEnumerable<SemesterResponseDto>> GetAllAsync();
        Task<SemesterResponseDto?> GetByIdAsync(int id);
        Task CreateAsync(SemesterCreateDto dto);
        Task UpdateAsync(int id, SemesterCreateDto dto);
        Task DeleteAsync(int id);
    }
}
