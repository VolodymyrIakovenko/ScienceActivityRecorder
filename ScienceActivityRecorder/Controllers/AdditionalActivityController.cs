﻿using Microsoft.AspNetCore.Mvc;
using ScienceActivityRecorder.ViewModels;
using ScienceActivityRecorder.Models;
using ScienceActivityRecorder.Enums;

namespace ScienceActivityRecorder.Controllers
{
    public class AdditionalActivityController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new AdditionalActivityIndexViewModel
            {
                AdditionalActivityInfo = new AdditionalActivityInfo
                {
                    Id = 1
                }
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
                viewModel.OperationResult = OperationResult.Success;
            }

            return View(viewModel);
        }
    }
}