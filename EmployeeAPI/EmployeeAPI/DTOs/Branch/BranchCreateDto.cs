using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.DTOs.Branch
{
    public class BranchCreateDto
    {
        [Required(ErrorMessage = "Branch name is required")]
        [StringLength(50,
    ErrorMessage = "Branch name cannot exceed 50 characters")]

        public string BranchName { get; set; }
    }
}
