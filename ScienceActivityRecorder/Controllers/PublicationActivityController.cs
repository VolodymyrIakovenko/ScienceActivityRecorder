using Microsoft.AspNetCore.Mvc;
using ScienceActivityRecorder.Enums;
using ScienceActivityRecorder.Models;
using ScienceActivityRecorder.Providers;
using ScienceActivityRecorder.ViewModels;

namespace ScienceActivityRecorder.Controllers
{
    public class PublicationActivityController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new PublicationActivityIndexViewModel
            {
                PublicationActivityInfo = ProfileProvider.IakovenkoOE.PublicationActivityInfo
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(PublicationActivityIndexViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.OperationResult = OperationResult.Error;
            }
            else
            {
                viewModel.OperationResult = OperationResult.Success;
            }

            return View(viewModel);
        }

        public IActionResult AuthorSearch()
        {
            var viewModel = new AuthorSearchRequestViewModel
            {
                AuthorSearchRequest = new AuthorSearchRequest
                {
                    NameSurname = string.Format("{0} {1}", ProfileProvider.IakovenkoOE.PersonalInfo.FirstName, ProfileProvider.IakovenkoOE.PersonalInfo.LastName),
                    NumberOfRecords = 10
                }
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AuthorSearch(AuthorSearchRequestViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            return RedirectToAction("AuthorSearchResults");
        }

        public IActionResult AuthorSearchResults()
        {
            return View();
        }
    }
}