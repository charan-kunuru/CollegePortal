using EmployeeAPI.DTOs.Branch;
using EmployeeAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _service;

        public BranchController(IBranchService service)
        {
            _service = service;
        }

        // GET: api/branch
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var branches = await _service.GetAllBranchesAsync();

            var response = branches.Select(b => new BranchResponseDto
            {
                BranchId = b.BranchId,
                BranchName = b.BranchName
            });

            return Ok(response);
        }

        // GET: api/branch/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var branch = await _service.GetByIdAsync(id);

            if (branch == null)
                return NotFound();

            var response = new BranchResponseDto
            {
                BranchId = branch.BranchId,
                BranchName = branch.BranchName
            };

            return Ok(response);
        }

        // POST: api/branch
        [HttpPost]
        public async Task<IActionResult> Create(BranchCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.CreateAsync(dto);

            return Ok(new { message = "Branch created successfully" });
        }

        // PUT: api/branch/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BranchCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var branch = await _service.GetByIdAsync(id);
            if (branch == null)
                return NotFound();

            await _service.UpdateAsync(id, dto);

            return Ok(new { message = "Branch updated successfully" });
        }

        // DELETE: api/branch/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var branch = await _service.GetByIdAsync(id);
            if (branch == null)
                return NotFound();

            await _service.DeleteAsync(id);

            return Ok(new { message = "Branch deleted successfully" });
        }
    }
}
