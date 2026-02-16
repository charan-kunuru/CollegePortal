using CollegeAPI.Modules.Branches.Models;
using CollegeAPI.Models;

namespace CollegeAPI.Modules.Branches.Repositories.Interface
{
    public interface IBranchRepository
    {

        Task<PagedResponse<Branch>> GetBranchesAsync(string? search, PagedRequest request);
        Task<Branch> GetByIdAsync(int id);
        Task AddAsync(Branch branch);
        Task UpdateAsync(Branch branch);
        Task DeleteAsync(Branch branch);
        Task<bool> BranchExists(string branchName);

    }
}
