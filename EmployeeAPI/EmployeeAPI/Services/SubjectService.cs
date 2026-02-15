using EmployeeAPI.DTOs.Subject;
using EmployeeAPI.Models;
using EmployeeAPI.Repositories.Interface;
using EmployeeAPI.Services.Interface;
namespace EmployeeAPI.Services
{

    public class SubjectService:ISubjectService
    {
        private readonly ISubjectRepository _repo;

        public SubjectService(ISubjectRepository repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<SubjectDto>> GetAllAsync()
        {
            var subjects = await _repo.GetAllAsync();

            return subjects.Select(s => new SubjectDto
            {
                SubjectId = s.SubjectId,
                SubjectName = s.SubjectName,
                SemesterId = s.SemesterId,
                SemesterName = "Semester " + s.Semester.SemesterNo
            }).ToList();
        }

        public async Task<SubjectDto?> GetByIdAsync(int id)
        {
            var subject = await _repo.GetByIdAsync(id);
            if (subject == null) return null;

            return new SubjectDto
            {
                SubjectId = subject.SubjectId,
                SubjectName = subject.SubjectName,
                SemesterId = subject.SemesterId,
                SemesterName = "Semester " + subject.Semester.SemesterNo
            };
        }

        public async Task<SubjectDto> CreateAsync(SubjectDto dto)
        {
            var subject = new Subject
            {
                SubjectName = dto.SubjectName,
                SemesterId = dto.SemesterId
            };

            await _repo.AddAsync(subject);

            dto.SubjectId = subject.SubjectId;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, SubjectDto dto)
        {
            var subject = await _repo.GetByIdAsync(id);
            if (subject == null) return false;

            subject.SubjectName = dto.SubjectName;
            subject.SemesterId = dto.SemesterId;

            await _repo.UpdateAsync(subject);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var subject = await _repo.GetByIdAsync(id);
            if (subject == null) return false;

            await _repo.DeleteAsync(subject);
            return true;
        }
    }
}
