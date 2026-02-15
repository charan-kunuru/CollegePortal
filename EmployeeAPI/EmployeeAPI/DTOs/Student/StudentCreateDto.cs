using System.ComponentModel.DataAnnotations;
namespace EmployeeAPI.DTOs.Student
{
    public class StudentCreateDto
    {

        [Required(ErrorMessage = "Subject name is required")]
        [StringLength(100,
                ErrorMessage = "Subject name cannot exceed 100 characters")]
        public string Name { get; set; }

        [Range(1,100,ErrorMessage ="Age should be in between 1 and 100")]
        public int Age { get; set; }
    }
}
