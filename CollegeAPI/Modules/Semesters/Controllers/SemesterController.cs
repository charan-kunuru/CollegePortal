using CollegeAPI.Modules.Semesters.Dtos;
using CollegeAPI.Modules.Semesters.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CollegeAPI.Models;
using System.Threading.Tasks;
namespace CollegeAPI.Modules.Semesters.Controllers;

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
    public async Task<IActionResult> GetSemesters(
        [FromQuery] string? search,
        [FromQuery] PagedRequest request)
    {
        var result = await _service.GetSemestersAsync(search, request);
        return Ok(result);
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
        var success = await _service.CreateSemesterAsync(dto);

        if (!success)
        {
            return BadRequest("Semester already exists for this branch.");
        }

        return Ok();
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
