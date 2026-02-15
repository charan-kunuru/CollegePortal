using EmployeeAPI.DTOs.Branch;

namespace EmployeeAPI.Services.Interface
{
    public interface IBranchService
    {
        Task<List<BranchResponseDto>> GetAllBranchesAsync();
        Task<BranchResponseDto> GetByIdAsync(int id);
        Task CreateAsync(BranchCreateDto dto);
        Task UpdateAsync(int id, BranchCreateDto dto);
        Task DeleteAsync(int id);
    }
}
