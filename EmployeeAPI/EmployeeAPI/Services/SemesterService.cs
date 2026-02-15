using EmployeeAPI.Models;
using EmployeeAPI.Services.Interface;
using EmployeeAPI.Repositories.Interface;
using EmployeeAPI.DTOs.Semester;

namespace EmployeeAPI.Services
{
    public class SemesterService : ISemesterService
    {
        private readonly ISemesterRepository _repo;

        public SemesterService(ISemesterRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<SemesterResponseDto>> GetAllAsync()
        {
            var semesters = await _repo.GetAllAsync();

            return semesters.Select(s => new SemesterResponseDto
            {
                SemesterId = s.SemesterId,
                SemesterNo = s.SemesterNo,
                BranchId = s.BranchId,
                BranchName = s.Branch?.BranchName
            }).ToList();
        }

        public async Task<SemesterResponseDto?> GetByIdAsync(int id)
        {
            var semester = await _repo.GetByIdAsync(id);

            if (semester == null) return null;

            return new SemesterResponseDto
            {
                SemesterId = semester.SemesterId,
                SemesterNo = semester.SemesterNo,
                BranchId = semester.BranchId,
                BranchName = semester.Branch?.BranchName
            };
        }

        public async Task CreateAsync(SemesterCreateDto dto)
        {
            var semester = new Semester
            {
                SemesterNo = dto.SemesterNo,
                BranchId = dto.BranchId
            };
           await _repo.AddAsync(semester);
        }

        public async Task UpdateAsync(int id, SemesterCreateDto dto)
        {
            var semester = await _repo.GetByIdAsync(id);
            if (semester == null) return;

            semester.SemesterNo = dto.SemesterNo;
            semester.BranchId = dto.BranchId;

            await _repo.UpdateAsync(semester);
        }

        public async Task DeleteAsync(int id)
        {
            var semester = await _repo.GetByIdAsync(id);
            if (semester == null) return;

            await _repo.DeleteAsync(semester);
          
        }
    }
}
