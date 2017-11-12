using Microsoft.AspNetCore.Mvc;
using ScienceActivityRecorder.Providers;
using ScienceActivityRecorder.Repositories;

namespace ScienceActivityRecorder.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProfilesRepository _profilesRepository;

        public HomeController(IProfilesRepository profilesRepository)
        {
            _profilesRepository = profilesRepository;
        }

        public IActionResult Index()
        {
            var profile = _profilesRepository.GetProfile(ScientistProfileProvider.Index);
            return View(profile);
        }
    }
}
