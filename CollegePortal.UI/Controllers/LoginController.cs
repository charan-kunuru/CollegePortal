using CollegePortal.UI.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace CollegePortal.UI.Controllers
{
    public class LoginController : Controller
    {

        private readonly HttpClient _httpClient;
        public LoginController(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("EmployeeAPI");
        }
        [ResponseCache(NoStore =true,Location =ResponseCacheLocation.None)]
        [HttpGet]
        public  async Task<IActionResult> Login()
        {
            var token = HttpContext.Session.GetString("JWT");

            if (!string.IsNullOrEmpty(token))
            {
                var role = HttpContext.Session.GetString("UserRole");

                return role switch
                {
                    "Admin" => RedirectToAction("AdminDashboard", "Dashboard"),
                    "Student" => RedirectToAction("Index", "Student"),
                    "Teacher" => RedirectToAction("Index", "Teacher"),
                    _ => View()
                };
            }
            return View();
        }
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestVM model)
        {

            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var response = await _httpClient.PostAsJsonAsync(
                 "api/auth/login", model);


                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError("", error);
                    return View(model);   // IMPORTANT: stop here
                }

                var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponseVM>();
                //  return loginResponse;

                if (loginResponse == null)
                {
                    ViewBag.ErrorMessage = "Invalid UserId or Password";
                    return View(model);

                }
                HttpContext.Session.SetString("JWT", loginResponse.Token);
                HttpContext.Session.SetString("UserRole", loginResponse.Role);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.UserName),
                    new Claim(ClaimTypes.Role, loginResponse.Role)
                };

                var identity = new ClaimsIdentity(
                    claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    principal);

                return loginResponse.Role switch
                {
                    "Admin" => RedirectToAction("AdminDashboard", "Dashboard"),
                    "Student" => RedirectToAction("Index", "Student"),
                    "Teacher" => RedirectToAction("Index", "Teacher"),
                    _ => RedirectToAction("Login")
                };
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error parsing login response", ex);
            }


        }
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();

            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Login");
        }


    }
}
