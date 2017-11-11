﻿using Microsoft.AspNetCore.Mvc;
using ScienceActivityRecorder.Enums;
using ScienceActivityRecorder.Providers;
using ScienceActivityRecorder.ViewModels;

namespace ScienceActivityRecorder.Controllers
{
    public class ProfessionalActivityController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new ProfessionalActivityIndexViewModel
            {
                ProfessionalActivity = ScientistProfileProvider.IakovenkoOE.ProfessionalActivityInfo
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
                viewModel.OperationResult = OperationResult.Success;
            }
            
            return View(viewModel);
        }
    }
}