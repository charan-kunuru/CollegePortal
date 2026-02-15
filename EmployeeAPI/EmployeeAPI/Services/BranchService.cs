using EmployeeAPI.DTOs.Branch;
using EmployeeAPI.Models;
using EmployeeAPI.Repositories.Interface;
using EmployeeAPI.Services.Interface;
using Microsoft.EntityFrameworkCore;
namespace EmployeeAPI.Services
{
    public class BranchService:IBranchService
    {
        private readonly IBranchRepository _Repo;
        public BranchService(IBranchRepository Repo) 
        {
            _Repo= Repo;
        }
        public async Task<List<BranchResponseDto>> GetAllBranchesAsync()
        {
            var branches = await _Repo.GetAllAsync();
            return branches.Select(b => new BranchResponseDto
            {
                BranchId = b.BranchId,
                BranchName = b.BranchName,
            }).ToList();
        }
        public async Task<BranchResponseDto> GetByIdAsync(int id)
        {
            var branch = await _Repo.GetByIdAsync(id);

            if (branch == null) return null;

            return new BranchResponseDto
            {
                BranchId = branch.BranchId,
                BranchName = branch.BranchName
            };
        }

        public async Task CreateAsync(BranchCreateDto dto)
        {
            var exists = await _Repo.BranchExists(dto.BranchName);
            if (exists) return ;

            var branch = new Branch
            {
                BranchName = dto.BranchName
            };

            await _Repo.AddAsync(branch);
        }

        public async Task UpdateAsync(int id, BranchCreateDto dto)
        {
            var branch = await _Repo.GetByIdAsync(id);
            if (branch == null) return;

            branch.BranchName = dto.BranchName;

            await _Repo.UpdateAsync(branch);
        }
        public async Task DeleteAsync(int id)
        {
            var branch = await _Repo.GetByIdAsync(id);
            if (branch == null) return;

            await _Repo.DeleteAsync(branch);
        }
    }
}
