using Microsoft.AspNetCore.Mvc;
using CollegePortal.UI.Controllers;
using Microsoft.AspNetCore.Authorization;

namespace CollegePortal.UI.Controllers
{
 
    public class DashboardController :BaseController
    {
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> AdminDashboard()
        {
            return View();  
        }
    }
}
