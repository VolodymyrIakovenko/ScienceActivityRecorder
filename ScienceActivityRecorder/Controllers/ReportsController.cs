using Microsoft.AspNetCore.Mvc;

namespace ScienceActivityRecorder.Controllers
{
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