using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.DTOs.Auth
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
