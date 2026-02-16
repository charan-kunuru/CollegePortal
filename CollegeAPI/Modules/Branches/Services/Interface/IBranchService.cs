using CollegeAPI.Modules.Branches.Dtos;
using CollegeAPI.Modules.Branches.Repositories.Interface;
using CollegeAPI.Modules.Branches.Services.Interface;
using CollegeAPI.Models;

namespace CollegeAPI.Modules.Branches.Services.Interface
{
    public interface IBranchService
    {
        Task<PagedResponse<BranchResponseDto>> GetBranchesAsync(string? search, PagedRequest request);
        Task<BranchResponseDto> GetByIdAsync(int id);
        Task CreateAsync(BranchCreateDto dto);
        Task UpdateAsync(int id, BranchCreateDto dto);
        Task DeleteAsync(int id);
    }
}
