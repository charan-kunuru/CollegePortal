using System.ComponentModel.DataAnnotations;
namespace EmployeeAPI.DTOs.Admin
{
    public class CreateUserDto
    {
        [Key]
        public int Id { get; set; }

        public string RollNo { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
