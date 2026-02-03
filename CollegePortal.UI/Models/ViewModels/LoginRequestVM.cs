using System.ComponentModel.DataAnnotations;
namespace CollegePortal.UI.Models.ViewModels
{
    public class LoginRequestVM
    {

        [Required(ErrorMessage ="UserName is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
