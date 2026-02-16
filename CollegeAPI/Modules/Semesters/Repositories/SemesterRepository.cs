using CollegeAPI.Data;
using Microsoft.EntityFrameworkCore;
using CollegeAPI.Models;
using CollegeAPI.Modules.Semesters.Repositories.Interface;
using CollegeAPI.Modules.Semesters.Models;

namespace CollegeAPI.Modules.Semesters.Repositories
{
    public class SemesterRepository: ISemesterRepository
    {
        private readonly AppDbContext _context;
        public SemesterRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResponse<Semester>> GetSemestersAsync(string? search, PagedRequest request)
        {
            var query = _context.Semesters
    .Include(s => s.Branch)   // Include related Branch
    .AsQueryable();

            // Search by SemesterNo (integer)
            if (!string.IsNullOrWhiteSpace(search))
            {
                if (int.TryParse(search, out int semesterNo))
                {
                    query = query.Where(s => s.SemesterNo == semesterNo);
                }
            }

            var totalRecords = await query.CountAsync();

            var semesters = await query
                .OrderBy(s => s.SemesterNo)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            return new PagedResponse<Semester>(
                semesters,
                totalRecords,
                request.PageNumber,
                request.PageSize
            );
        }

        public async Task<Semester?> GetByIdAsync(int id)
        {
            return await _context.Semesters
                .Include(s => s.Branch)
                .FirstOrDefaultAsync(s => s.SemesterId == id);
        }
        public async Task<bool> SemesterExistsAsync(int branchId, int semesterNo)
        {
            return await _context.Semesters
                .AnyAsync(s =>
                    s.BranchId == branchId &&
                    s.SemesterNo == semesterNo);
        }
        public async Task<Semester> AddAsync(Semester semester)
        {
            _context.Semesters.Add(semester);
            await _context.SaveChangesAsync();
            return semester;
        }

        public async Task UpdateAsync(Semester semester)
        {
            _context.Semesters.Update(semester);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Semester semester)
        {
            _context.Semesters.Remove(semester);
            await _context.SaveChangesAsync();
        }

    }
}
