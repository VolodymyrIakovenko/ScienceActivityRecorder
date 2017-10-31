using Microsoft.AspNetCore.Mvc;
using ScienceActivityRecorder.Enums;
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
    }
}