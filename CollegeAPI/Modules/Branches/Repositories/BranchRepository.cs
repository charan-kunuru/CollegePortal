
using Microsoft.EntityFrameworkCore;
using CollegeAPI.Models;
using CollegeAPI.Modules.Branches.Models;
using CollegeAPI.Modules.Branches.Repositories.Interface;
using CollegeAPI.Data;
namespace CollegeAPI.Modules.Branches.Repositories
{
    public class BranchRepository:IBranchRepository
    {
        private readonly AppDbContext _context;
        public BranchRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<PagedResponse<Branch>> GetBranchesAsync(string? search, PagedRequest request)
        {
            var query = _context.Branches.AsNoTracking().AsQueryable();

            // Search by branch name
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim().ToLower();
                query = query.Where(b =>
                    b.BranchName.Contains(search));
            }

            var totalRecords = await query.CountAsync();

            var branches = await query
                .OrderBy(b => b.BranchId)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            return new PagedResponse<Branch>(
                branches,
                totalRecords,
                request.PageNumber,
                request.PageSize
            );
        }


        public async Task<Branch> GetByIdAsync(int id)
        {
            return await _context.Branches.FindAsync(id);
        }
        public async Task<bool> BranchExists(string branchName)
        {
            return await _context.Branches
                .AnyAsync(b => b.BranchName == branchName);
        }
        public async Task AddAsync(Branch branch)
        {
            _context.Branches.Add(branch);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Branch branch)
        {
             _context.Branches.Update(branch);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Branch branch)
        {
            _context.Branches.Remove(branch);
            await _context.SaveChangesAsync();
        }

    }
}
