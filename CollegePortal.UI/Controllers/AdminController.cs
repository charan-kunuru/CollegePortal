using Microsoft.AspNetCore.Mvc;
using CollegePortal.UI.Models.ViewModels;
using System.Net.Http.Headers;
using CollegePortal.UI.Controllers;
using System.Net.Http.Json;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
namespace CollegePortal.UI.Controllers
{
    public class AdminController : BaseController
    {
        private readonly HttpClient _httpClient;

        public AdminController(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("EmployeeAPI");
        }

        private void AddToken()
        {
            var token = HttpContext.Session.GetString("JWT");

            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
        }

        public async Task<IActionResult> Index()
        {
            AddToken();
            var response = await _httpClient.GetAsync("api/admin");

            if (!response.IsSuccessStatusCode)
                return View(new List<AllUsersVM>());

            var users = await response.Content.ReadFromJsonAsync<List<AllUsersVM>>();
            return View(users ?? new List<AllUsersVM>());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            AddToken();


            var dto = new
            {
                userName = model.UserName,
                password = model.Password,
                role = model.Role.ToString()   // IMPORTANT
            };

            var response = await _httpClient.PostAsJsonAsync("api/admin",dto);

            if (!response.IsSuccessStatusCode)
                return View(model);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            AddToken();
            var response = await _httpClient.GetAsync($"api/admin/{id}");

            if (!response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            var user = await response.Content.ReadFromJsonAsync<AllUsersVM>();
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AllUsersVM model)
        {
            AddToken();
            var response = await _httpClient.PutAsJsonAsync($"api/admin/{model.Id}", model);

            if (!response.IsSuccessStatusCode)
                return View(model);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            AddToken();
            var response = await _httpClient.GetAsync($"api/admin/{id}");

            if (!response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            var user = await response.Content.ReadFromJsonAsync<AllUsersVM>();
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            AddToken();
            await _httpClient.DeleteAsync($"api/admin/{id}");
            return RedirectToAction("Index");
        }



    }
}



