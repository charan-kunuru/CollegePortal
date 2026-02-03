using Microsoft.AspNetCore.Mvc;
using CollegePortal.UI.Models.ViewModels;
using System.Net.Http.Headers;

public class AdminController : Controller
{
    private readonly IHttpClientFactory _httpClient;

    public AdminController(IHttpClientFactory httpClient)
    {
        _httpClient =httpClient ;
    }



    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserVM model)
    {
        var token = HttpContext.Session.GetString("JWT");

        var client = _httpClient.CreateClient();
        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

        var response = await client.PostAsJsonAsync(
            "https://localhost:7045/api/admin/create-user", model);

        if (!response.IsSuccessStatusCode)
            return View("Error");

        return RedirectToAction("CreateUser");
    }
}



