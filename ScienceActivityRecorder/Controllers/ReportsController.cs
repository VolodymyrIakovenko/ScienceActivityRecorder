using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ScienceActivityRecorder.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        public IActionResult Generate()
        {
            return View();
        }

        public IActionResult Visualize()
        {
            return View();
        }
    }
}