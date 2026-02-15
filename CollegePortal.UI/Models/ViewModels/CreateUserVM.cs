using CollegePortal.UI.Enum;
namespace CollegePortal.UI.Models.ViewModels
{
    public class CreateUserVM
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
