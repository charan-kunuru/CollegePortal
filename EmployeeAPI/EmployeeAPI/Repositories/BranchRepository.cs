using EmployeeAPI.Repositories.Interface;
using EmployeeAPI.Data;
using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Models;
namespace EmployeeAPI.Repositories
{
    public class BranchRepository:IBranchRepository
    {
        private readonly AppDbContext _context;
        public BranchRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Branch>> GetAllAsync()
        {
            return await _context.Branches.ToListAsync();
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
