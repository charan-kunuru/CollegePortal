using CollegePortal.UI.Models.ViewModels;

namespace CollegePortal.UI.Services.Interfaces
{
    public interface ILoginService
    {
        Task<LoginResponseVM?> LoginAsync(LoginRequestVM model);
    }
}
