using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScienceActivityRecorder.Enums;
using ScienceActivityRecorder.Providers;
using ScienceActivityRecorder.Repositories;
using ScienceActivityRecorder.ViewModels;
using System.Linq;

namespace ScienceActivityRecorder.Controllers
{
    [Authorize]
    public class ProfessionalActivityController : Controller
    {
        private readonly IProfilesRepository _profilesRepository;

        public ProfessionalActivityController(IProfilesRepository profilesRepository)
        {
            _profilesRepository = profilesRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var profile = _profilesRepository.GetProfile(ScientistProfileProvider.Index);
            var professionalActivity = profile.ProfessionalActivity.FirstOrDefault(p => p.LastFillDate == ScientistProfileProvider.NextLastFillDate);

            var viewModel = new ProfessionalActivityIndexViewModel
            {
                ProfessionalActivity = professionalActivity
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ProfessionalActivityIndexViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.OperationResult = OperationResult.Error;
            }
            else
            {
                var profile = _profilesRepository.GetProfile(ScientistProfileProvider.Index);
                var professionalActivity = profile.ProfessionalActivity.FirstOrDefault(p => p.Id == viewModel.ProfessionalActivity.Id);
                if (professionalActivity == null)
                {
                    viewModel.OperationResult = OperationResult.Error;
                }
                else
                {
                    var index = profile.ProfessionalActivity.IndexOf(professionalActivity);
                    profile.ProfessionalActivity[index] = viewModel.ProfessionalActivity;
                    _profilesRepository.UpdateProfile(profile);

                    viewModel.OperationResult = OperationResult.Success;
                }
            }
            
            return View(viewModel);
        }
    }
}