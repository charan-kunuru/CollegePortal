using System.ComponentModel.DataAnnotations;

namespace CollegeAPI.Modules.Auth.Dtos
{
    public class LoginRequestDto
    {

        [Required(ErrorMessage = "User ID is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}
