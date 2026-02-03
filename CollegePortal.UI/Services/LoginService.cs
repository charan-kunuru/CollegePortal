using CollegePortal.UI.Models.ViewModels;
using CollegePortal.UI.Services.Interfaces;
using System.Net.Http.Json;

namespace CollegePortal.UI.Services
{
    public class LoginService: ILoginService
    {
        private readonly HttpClient _httpClient;
        public LoginService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<LoginResponseVM?> LoginAsync(LoginRequestVM model)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "https://localhost:7045/api/auth/login", model);
            if (!response.IsSuccessStatusCode)
                return null;
            var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponseVM>();
            return loginResponse;
        }
    }
}
