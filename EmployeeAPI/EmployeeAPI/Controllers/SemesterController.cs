using EmployeeAPI.DTOs.Branch;
using EmployeeAPI.DTOs.Semester;
using EmployeeAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]

    public class SemesterController : ControllerBase
    {
        private readonly ISemesterService _service;

        public SemesterController(ISemesterService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var result = await _service.GetAllAsync();
            var response = result.Select(b => new SemesterResponseDto
            {
                SemesterNo = b.SemesterNo,
                SemesterId = b.SemesterId,
                BranchName = b.BranchName,
                BranchId = b.BranchId
            });
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            var response = new SemesterResponseDto
            {
                SemesterNo = result.SemesterNo,
                SemesterId = result.SemesterId,
                BranchName = result.BranchName,
                BranchId = result.BranchId
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SemesterCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _service.CreateAsync(dto);
            return Ok("Semester created successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SemesterCreateDto dto)
        {
            
             await _service.UpdateAsync(id, dto);
            return Ok("Semester updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Semester deleted successfully");
        }
    }
}
