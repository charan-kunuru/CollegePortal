using EmployeeAPI.Data;
using EmployeeAPI.Models;
using EmployeeAPI.Repositories.Interface;
namespace EmployeeAPI.Repositories
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
