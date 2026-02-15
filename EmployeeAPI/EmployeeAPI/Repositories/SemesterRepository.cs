using EmployeeAPI.Repositories.Interface;
using EmployeeAPI.Data;
using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Models;

namespace EmployeeAPI.Repositories
{
    public class SemesterRepository: ISemesterRepository
    {
        private readonly AppDbContext _context;
        public SemesterRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Semester>> GetAllAsync()
        {
            return await _context.Semesters
                .Include(s => s.Branch)
                .ToListAsync();
        }

        public async Task<Semester?> GetByIdAsync(int id)
        {
            return await _context.Semesters
                .Include(s => s.Branch)
                .FirstOrDefaultAsync(s => s.SemesterId == id);
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
