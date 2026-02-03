using Microsoft.AspNetCore.Mvc;
using CollegePortal.UI.Models.ViewModels;
using System.Net.Http.Headers;
using CollegePortal.UI.Services.Interfaces;

namespace CollegePortal.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _service;
        public LoginController(ILoginService service)
        {
            _service = service;
        }

        [HttpGet]
        public  async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestVM model)
        {

            if (!ModelState.IsValid)
                return View(model);

            var response = await _service.LoginAsync(model);

            if (response== null)
            {
                ViewBag.ErrorMessage = "Invalid UserId or Password";
                return View(model);

            }
                


  
            HttpContext.Session.SetString("JWT", response.Token);
            HttpContext.Session.SetString("UserRole",response.Role);

            return response.Role switch
            {
               "Admin" => RedirectToAction("Index", "Admin"),
                "Student" => RedirectToAction("Index", "Student"),
                "Teacher" => RedirectToAction("Index", "Teacher"),
                _ => View("Invalid UserId")
            };
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginAsync");
        }

    }
}
