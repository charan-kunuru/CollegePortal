using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.DTOs.Subject
{
    public class SubjectDto
    {
        [Required(ErrorMessage = "Subject  Id is required")]
        public int SubjectId { get; set; }
        [Required(ErrorMessage = "Subject name is required")]
        [StringLength(100,
    ErrorMessage = "Subject name cannot exceed 100 characters")]
        public string SubjectName { get; set; }
        [Required(ErrorMessage = "SemesterId is required")]
        public int SemesterId { get; set; }
        [Required(ErrorMessage = "Semester name is required")]
        public string SemesterName { get; set; }
    }
}
