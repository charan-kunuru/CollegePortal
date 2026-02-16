using CollegeAPI.Data;
using Microsoft.EntityFrameworkCore;
using CollegeAPI.Models;
using CollegeAPI.Modules.Subjects.Models;
using CollegeAPI.Modules.Subjects.Repositories.Interface;
namespace CollegeAPI.Modules.Subjects.Repositories
{
    public class SubjectRepository:ISubjectRepository
    {
        private readonly AppDbContext _context;
        public SubjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            return await _context.Subjects
                .Include(s => s.Semester)
                .ToListAsync();
        }

        public async Task<Subject?> GetByIdAsync(int id)
        {
            return await _context.Subjects
                .Include(s => s.Semester)
                .FirstOrDefaultAsync(s => s.SubjectId == id);
        }

        public async Task<Subject> AddAsync(Subject subject)
        {
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
            return subject;
        }

        public async Task UpdateAsync(Subject subject)
        {
            _context.Subjects.Update(subject);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Subject subject)
        {
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
        }
    }
}
