using Microsoft.AspNetCore.Mvc;

namespace ScienceActivityRecorder.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PublicationActivity()
        {
            return View();
        }

        public IActionResult ProfessionalActivity()
        {
            return View();
        }

        public IActionResult Reports()
        {
            return View();
        }
    }
}
