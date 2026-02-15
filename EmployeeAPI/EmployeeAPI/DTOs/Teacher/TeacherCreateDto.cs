using EmployeeAPI.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace EmployeeAPI.DTOs.Teacher
{
    public class TeacherCreateDto
    {
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength (30)]
        public string LastName { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        [Range(18, 30, ErrorMessage = "Age must be between 18 and 30.")]
        public int Age { get; set; }
        public string?  PhotoPath { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateOnly Dob { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }

        public string Gender { get; set; }
        [DataType(DataType.PhoneNumber)]
        public int MobileNumber { get; set; }


        [DataType(DataType.Date)]
        public DateOnly Joined { get; set; }


    }
}
