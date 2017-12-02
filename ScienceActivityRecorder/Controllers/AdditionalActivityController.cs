using Microsoft.AspNetCore.Mvc;
using ScienceActivityRecorder.ViewModels;
using ScienceActivityRecorder.Enums;
using ScienceActivityRecorder.Providers;
using ScienceActivityRecorder.Repositories;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using ScienceActivityRecorder.Models;

namespace ScienceActivityRecorder.Controllers
{
    [Authorize]
    public class AdditionalActivityController : Controller
    {
        private readonly IProfileProvider _profileProvider;
        private readonly IProfilesRepository _profilesRepository;

        public AdditionalActivityController(IProfilesRepository profilesRepository)
        {
            _profilesRepository = profilesRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var profile = ViewBag.Profile as Profile;
            var additionalActivity = profile.AdditionalActivity.FirstOrDefault(p => p.LastFillDate == ProfileProvider.NextLastFillDate);

            var viewModel = new AdditionalActivityIndexViewModel
            {
                AdditionalActivity = additionalActivity
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(AdditionalActivityIndexViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.OperationResult = OperationResult.Error;
            }
            else
            {
                var profile = ViewBag.Profile as Profile;
                var additionalActivity = profile.AdditionalActivity.FirstOrDefault(p => p.Id == viewModel.AdditionalActivity.Id);
                if (additionalActivity == null)
                {
                    viewModel.OperationResult = OperationResult.Error;
                }
                else
                {
                    var index = profile.AdditionalActivity.IndexOf(additionalActivity);
                    profile.AdditionalActivity[index] = viewModel.AdditionalActivity;
                    _profilesRepository.UpdateProfile(profile);

                    viewModel.OperationResult = OperationResult.Success;
                }
            }

            return View(viewModel);
        }
    }
}