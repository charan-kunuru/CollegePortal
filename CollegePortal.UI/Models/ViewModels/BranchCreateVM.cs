using System.ComponentModel.DataAnnotations;

namespace CollegePortal.UI.Models.ViewModels
{
    public class BranchCreateVM
    {
        public int BranchId { get; set; }
        [Required(ErrorMessage = "Branch name is required")]
        [StringLength(50)]
        public string BranchName {  get; set; } 
    }
}
