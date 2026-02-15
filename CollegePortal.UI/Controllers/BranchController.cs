using CollegePortal.UI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace CollegePortal.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BranchController : BaseController
    {
        private readonly HttpClient _httpClient;

        public BranchController(IHttpClientFactory httpClientFactory)
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

        // GET: Branch
        public async Task<IActionResult> Index()
        {
            AddToken();

            var response = await _httpClient.GetAsync("api/branch");

            if (!response.IsSuccessStatusCode)
            {
                TempData["Error"] = "Failed to load branches.";
                return RedirectToAction("AdminDashboard", "Dashboard");
            }

            var branches = await response.Content
                .ReadFromJsonAsync<List<BranchCreateVM>>();

            return View(branches);
        }

        // GET: Branch/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Branch/Create
        [HttpPost]
        public async Task<IActionResult> Create(BranchCreateVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            AddToken();
            var response = await _httpClient.PostAsJsonAsync("api/branch", model);

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Branch created successfully.";
                return RedirectToAction("Index");
            }

            var error = await response.Content.ReadAsStringAsync();
            ModelState.AddModelError("", string.IsNullOrEmpty(error)
                ? "Failed to create branch."
                : error);

            return View(model);
        }

        // GET: Branch/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            AddToken();

            var response = await _httpClient.GetAsync($"api/branch/{id}");

            if (!response.IsSuccessStatusCode)
            {
                TempData["Error"] = "Branch not found.";
                return RedirectToAction("Index");
            }

            var branch = await response.Content
                .ReadFromJsonAsync<BranchCreateVM>();

            return View(branch);
        }

        // POST: Branch/Edit
        [HttpPost]
      
        public async Task<IActionResult> Edit(BranchCreateVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            AddToken();
            var response = await _httpClient
                .PutAsJsonAsync($"api/branch/{model.BranchId}", model);

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Branch updated successfully.";
                return RedirectToAction("Index");
            }

            var error = await response.Content.ReadAsStringAsync();
            ModelState.AddModelError("", string.IsNullOrEmpty(error)
                ? "Failed to update branch."
                : error);

            return View(model);
        }

        // GET: Branch/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            AddToken();

            var response = await _httpClient.GetAsync($"api/branch/{id}");

            if (!response.IsSuccessStatusCode)
            {
                TempData["Error"] = "Branch not found.";
                return RedirectToAction("Index");
            }

            var branch = await response.Content
                .ReadFromJsonAsync<BranchCreateVM>();

            return View(branch);
        }

        // POST: Branch/Delete/5
        [HttpPost, ActionName("Delete")]
  
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            AddToken();

            var response = await _httpClient.DeleteAsync($"api/branch/{id}");

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Branch deleted successfully.";
            }
            else
            {
                TempData["Error"] = "Failed to delete branch.";
            }

            return RedirectToAction("Index");
        }
    }
}
