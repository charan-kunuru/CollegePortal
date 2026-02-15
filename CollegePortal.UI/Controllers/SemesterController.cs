using CollegePortal.UI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace CollegePortal.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SemesterController : BaseController
    {
        private readonly HttpClient _httpClient;

        public SemesterController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("EmployeeAPI");
        }

        private void AddToken()
        {
            var token = HttpContext.Session.GetString("JWT");

            if (!string.IsNullOrEmpty(token))
            {
                // Remove old header to avoid duplication
                if (_httpClient.DefaultRequestHeaders.Contains("Authorization"))
                {
                    _httpClient.DefaultRequestHeaders.Remove("Authorization");
                }

                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
        }

        // GET: Semester
        public async Task<IActionResult> Index()
        {
            AddToken();

            var response = await _httpClient.GetAsync("api/semester");

            if (!response.IsSuccessStatusCode)
            {
                TempData["Error"] = "Failed to load semesters.";
                return RedirectToAction("AdminDashboard", "Dashboard");
            }

            var semesters = await response.Content
                .ReadFromJsonAsync<List<SemesterResponseVM>>();

            return View(semesters);
        }

        // GET: Semester/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Semester/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SemesterCreateVM dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            AddToken();
            var response = await _httpClient.PostAsJsonAsync("api/semester", dto);

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Semester created successfully.";
                return RedirectToAction("Index");
            }

            var error = await response.Content.ReadAsStringAsync();
            ModelState.AddModelError("", string.IsNullOrEmpty(error)
                ? "Failed to create semester."
                : error);

            return View(dto);
        }

        // GET: Semester/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            AddToken();

            var response = await _httpClient.GetAsync($"api/semester/{id}");

            if (!response.IsSuccessStatusCode)
            {
                TempData["Error"] = "Semester not found.";
                return RedirectToAction("Index");
            }

            var semester = await response.Content
                .ReadFromJsonAsync<SemesterCreateVM>();

            return View(semester);
        }

        // POST: Semester/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SemesterCreateVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            AddToken();
            var response = await _httpClient
                .PutAsJsonAsync($"api/semester/{model.SemesterId}", model);

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Semester updated successfully.";
                return RedirectToAction("Index");
            }

            var error = await response.Content.ReadAsStringAsync();
            ModelState.AddModelError("", string.IsNullOrEmpty(error)
                ? "Failed to update semester."
                : error);

            return View(model);
        }

        // GET: Semester/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            AddToken();

            var response = await _httpClient.GetAsync($"api/semester/{id}");

            if (!response.IsSuccessStatusCode)
            {
                TempData["Error"] = "Semester not found.";
                return RedirectToAction("Index");
            }

            var semester = await response.Content
                .ReadFromJsonAsync<SemesterCreateVM>();

            return View(semester);
        }

        // POST: Semester/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            AddToken();

            var response = await _httpClient.DeleteAsync($"api/semester/{id}");

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Semester deleted successfully.";
                return RedirectToAction("Index");
            }

            TempData["Error"] = "Failed to delete semester.";
            return RedirectToAction("Index");
        }
    }
}
