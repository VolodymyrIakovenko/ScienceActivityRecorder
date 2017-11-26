using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScienceActivityRecorder.Models;

namespace ScienceActivityRecorder.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var profile = ViewBag.Profile as Profile;
            return View(profile);
        }
    }
}
