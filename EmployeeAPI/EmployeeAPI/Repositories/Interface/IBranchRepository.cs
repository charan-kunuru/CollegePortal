using EmployeeAPI.Models;

namespace EmployeeAPI.Repositories.Interface
{
    public interface IBranchRepository
    {
       
        Task<List<Branch>> GetAllAsync();
        Task<Branch> GetByIdAsync(int id);
        Task AddAsync(Branch branch);
        Task UpdateAsync(Branch branch);
        Task DeleteAsync(Branch branch);
        Task<bool> BranchExists(string branchName);

    }
}
