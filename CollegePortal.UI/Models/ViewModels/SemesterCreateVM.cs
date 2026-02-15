using System.ComponentModel.DataAnnotations;

namespace CollegePortal.UI.Models.ViewModels
{
    public class SemesterCreateVM
    {
        public int SemesterId { get; set; }

        [Required(ErrorMessage = "Semester number is required")]
        [Range(1, 8, ErrorMessage = "Semester must be between 1 and 8")]
        public int SemesterNo { get; set; }
        [Required(ErrorMessage = "Branch is required")]
        public int BranchId { get; set; }
    }
}
