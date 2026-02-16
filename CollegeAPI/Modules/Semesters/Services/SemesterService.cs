using CollegeAPI.Modules.Semesters.Dtos;
using CollegeAPI.Modules.Semesters.Repositories.Interface;
using CollegeAPI.Modules.Semesters.Services.Interface;
using CollegeAPI.Models;
using CollegeAPI.Modules.Semesters.Models;  


namespace CollegeAPI.Modules.Semesters.Services
{
    public class SemesterService : ISemesterService
    {
        private readonly ISemesterRepository _repo;

        public SemesterService(ISemesterRepository repo)
        {
            _repo = repo;
        }

        public async Task<PagedResponse<SemesterResponseDto>> GetSemestersAsync(string? search, PagedRequest request)
        {
            var pagedSemesters = await _repo.GetSemestersAsync(search, request);
            var semesterDtos = pagedSemesters.Data.Select(s => new SemesterResponseDto
            {
                SemesterId = s.SemesterId,
                SemesterNo = s.SemesterNo,
                BranchId = s.BranchId,
                BranchName = s.Branch.BranchName
            });

            return new PagedResponse<SemesterResponseDto>(
                semesterDtos,
                pagedSemesters.TotalRecords,
                pagedSemesters.PageNumber,
                pagedSemesters.PageSize
            );
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

        public async Task<bool> CreateSemesterAsync(SemesterCreateDto dto)
        {
            // Check if semester already exists for this branch
            var exists = await _repo
                .SemesterExistsAsync(dto.BranchId, dto.SemesterNo);

            if (exists)
            {
                return false; // or throw exception
            }

            var semester = new Semester
            {
                BranchId = dto.BranchId,
                SemesterNo = dto.SemesterNo
            };

            await _repo.AddAsync(semester);
            return true;
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
