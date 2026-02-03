using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace EmployeeAPI.DTOs.Teacher
{
    public class TeacherCreateDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }
        public string TeacherId { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(18, 65, ErrorMessage = "Age should be valid")]
        public int Age { get; set; }
        [Required]
        public bool IsActive { get; set; }

        public string PhotoPath { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateOnly Dob { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }


    }
}
