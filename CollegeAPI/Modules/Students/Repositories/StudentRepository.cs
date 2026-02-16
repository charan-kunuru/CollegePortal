using CollegeAPI.Modules.Students.Models;
using CollegeAPI.Data;
namespace CollegeAPI.Modules.Students.Repositories
{
    public class StudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
        }
    }
}
