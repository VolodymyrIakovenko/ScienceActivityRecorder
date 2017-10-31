using Microsoft.AspNetCore.Mvc;
using ScienceActivityRecorder.Enums;
using ScienceActivityRecorder.Models;
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
                PublicationActivityInfo = new PublicationActivityInfo
                {
                    Id = 1
                }
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