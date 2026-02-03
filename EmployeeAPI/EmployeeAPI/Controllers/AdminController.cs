using EmployeeAPI.Services.Interface;
using EmployeeAPI.DTOs.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        public AdminController(IUserService userService) 
        {
            _userService = userService;
        }
        [HttpPost("create-User")]
        public async Task<IActionResult> CreateUser(CreateUserDto dto)
        {
            var user=await _userService.CreateUserAsync(dto);
            return Ok(new
            {
                user.Id,
                user.RollNo,
                user.Role
            });
        }
    }
}
