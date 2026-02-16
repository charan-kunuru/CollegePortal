using System.ComponentModel.DataAnnotations;
namespace CollegeAPI.Modules.Users.Dtos
{
    public class CreateUserDto
    {
        
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3,
        ErrorMessage = "Name must be between 3 and 50 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6,
        ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }


    }
}
