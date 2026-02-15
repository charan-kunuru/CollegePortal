using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.DTOs.Semester
{
    public class SemesterCreateDto
    {
        [Required(ErrorMessage = "Semester number is required")]
        [Range(1, 8, ErrorMessage = "Semester must be between 1 and 8")]
        public int SemesterNo { get; set; }
        [Required(ErrorMessage = "Branch is required")]
        public int BranchId { get; set; }

    }
}
