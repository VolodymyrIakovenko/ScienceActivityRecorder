using Microsoft.AspNetCore.Mvc;
using ScienceActivityRecorder.Providers;

namespace ScienceActivityRecorder.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(PersonalInfoProvider.IakovenkoOE);
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
