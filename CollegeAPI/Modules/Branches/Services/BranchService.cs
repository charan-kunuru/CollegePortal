using CollegeAPI.Modules.Branches.Dtos;
using CollegeAPI.Modules.Branches.Repositories.Interface;
using CollegeAPI.Modules.Branches.Services.Interface;
using CollegeAPI.Models;
using CollegeAPI.Modules.Branches.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace CollegeAPI.Modules.Branches.Services
{
    public class BranchService:IBranchService
    {
        private readonly IBranchRepository _Repo;
        public BranchService(IBranchRepository Repo) 
        {
            _Repo= Repo;
        }

        public async Task<PagedResponse<BranchResponseDto>> GetBranchesAsync(string? search, PagedRequest request)
        {
            var pagedBranches = await _Repo.GetBranchesAsync(search, request);

            var branchDtos = pagedBranches.Data.Select(b => new BranchResponseDto
            {
                BranchId = b.BranchId,
                BranchName = b.BranchName
            });

            return new PagedResponse<BranchResponseDto>(
                branchDtos,
                pagedBranches.TotalRecords,
                pagedBranches.PageNumber,
                pagedBranches.PageSize
            );
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
