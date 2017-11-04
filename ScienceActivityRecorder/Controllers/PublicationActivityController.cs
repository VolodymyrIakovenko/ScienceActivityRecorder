﻿using Microsoft.AspNetCore.Mvc;
using ScienceActivityRecorder.Enums;
using ScienceActivityRecorder.GoogleScholarSearch;
using ScienceActivityRecorder.Models;
using ScienceActivityRecorder.Providers;
using ScienceActivityRecorder.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScienceActivityRecorder.Controllers
{
    public class PublicationActivityController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new PublicationActivityIndexViewModel
            {
                PublicationActivityInfo = ScientistProfileProvider.IakovenkoOE.PublicationActivityInfo
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

        [HttpGet]
        public IActionResult AuthorSearch()
        {
            var viewModel = new AuthorSearchRequestViewModel
            {
                AuthorSearchRequest = new AuthorSearchRequest
                {
                    NameSurname = string.Format("{0} {1}", ScientistProfileProvider.IakovenkoOE.PersonalInfo.FirstName, ScientistProfileProvider.IakovenkoOE.PersonalInfo.LastName),
                    NumberOfRecords = 10
                }
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AuthorSearch(AuthorSearchRequestViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var authorSearchRequest = viewModel.AuthorSearchRequest;

            var organizationAlternativeNames = OrganizationProvider.GetAlternativeNames(authorSearchRequest.Organization);

            var possibleOrganizations = new List<string>();
            if (!string.IsNullOrEmpty(authorSearchRequest.Organization))
            {
                possibleOrganizations.Add(authorSearchRequest.Organization);
                possibleOrganizations.AddRange(organizationAlternativeNames);
            }

            var profiles = await PageParser.GetProfilesFromAuthorSearch(authorSearchRequest.NameSurname, authorSearchRequest.NumberOfRecords, possibleOrganizations);

            return View("AuthorSearchResults", new AuthorSearchResultsViewModel
            {
                Authors = profiles.Take(authorSearchRequest.NumberOfRecords)
            });
        }
    }
}