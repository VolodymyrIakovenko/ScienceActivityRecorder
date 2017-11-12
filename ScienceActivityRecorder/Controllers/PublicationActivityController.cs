using Microsoft.AspNetCore.Mvc;
using ScienceActivityRecorder.Enums;
using ScienceActivityRecorder.GoogleScholarSearch;
using ScienceActivityRecorder.LatentSemanticAnalysis;
using ScienceActivityRecorder.LatentSemanticAnalysis.DataObjects;
using ScienceActivityRecorder.Models;
using ScienceActivityRecorder.Providers;
using ScienceActivityRecorder.Repositories;
using ScienceActivityRecorder.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScienceActivityRecorder.Controllers
{
    public class PublicationActivityController : Controller
    {
        private readonly IProfilesRepository _profilesRepository;

        public PublicationActivityController(IProfilesRepository profilesRepository)
        {
            _profilesRepository = profilesRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var profile = _profilesRepository.GetProfile(ScientistProfileProvider.Index);
            var publicationActivity = profile.PublicationActivity.FirstOrDefault(p => p.LastFillDate == ScientistProfileProvider.NextLastFillDate);

            var viewModel = new PublicationActivityIndexViewModel
            {
                PublicationActivity = publicationActivity
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IndexWithAuthorSearchResults(AuthorSearchResultsViewModel authorViewModel)
        {
            var viewModel = new PublicationActivityIndexViewModel
            {
                PublicationActivity = authorViewModel.PublicationActivity,
            };

            return View("Index", viewModel);
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
                var profile = _profilesRepository.GetProfile(ScientistProfileProvider.Index);
                var publicationActivity = profile.PublicationActivity.FirstOrDefault(p => p.Id == viewModel.PublicationActivity.Id);
                if (publicationActivity == null)
                {
                    viewModel.OperationResult = OperationResult.Error;
                }
                else
                {
                    var index = profile.PublicationActivity.IndexOf(publicationActivity);
                    profile.PublicationActivity[index] = viewModel.PublicationActivity;
                    _profilesRepository.UpdateProfile(profile);

                    viewModel.OperationResult = OperationResult.Success;
                }
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AuthorSearchWithPublicationParameters(PublicationActivityIndexViewModel publicationViewModel, bool isNum1, bool isNum2)
        {
            var profile = _profilesRepository.GetProfile(ScientistProfileProvider.Index);

            var viewModel = new AuthorSearchRequestViewModel
            {
                AuthorSearchRequest = new AuthorSearchRequest
                {
                    NameSurname = string.Format("{0} {1}", profile.FirstName, profile.LastName),
                    NumberOfRecords = 10
                },
                PublicationActivity = publicationViewModel.PublicationActivity,
                IsNum1 = isNum1,
                IsNum2 = isNum2
            };

            return View("AuthorSearch", viewModel);
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

            var profiles = new List<AuthorSearchResult>(await PageParser.GetProfilesFromAuthorSearch(authorSearchRequest.NameSurname, authorSearchRequest.NumberOfRecords, possibleOrganizations));

            IEnumerable<AuthorSearchResult> orderedProfiles = new List<AuthorSearchResult>();
            if (!string.IsNullOrEmpty(authorSearchRequest.Keywords))
            {
                var correlationProfiles = new Dictionary<AuthorSearchResult, double>();

                var lsa = new LSA(authorSearchRequest.Keywords, profiles.Select(a => string.Join("; ", a.Publications.Select(p => p.Name))));
                var correlations = new List<CorrelationItem>(lsa.GetCorrelations());
                for (var i = 0; i < profiles.Count(); i++)
                {
                    correlationProfiles.Add(profiles[i], correlations[i].Value);
                }

                var orderedCorrelationProfiles = correlationProfiles.OrderByDescending(k => k.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
                orderedProfiles = orderedCorrelationProfiles.Keys;
            }
            else
            {
                orderedProfiles = profiles.OrderByDescending(p => p.HIndex);
            }

            return View("AuthorSearchResults", new AuthorSearchResultsViewModel
            {
                Authors = orderedProfiles,
                PublicationActivity = viewModel.PublicationActivity,
                IsNum1 = viewModel.IsNum1,
                IsNum2 = viewModel.IsNum2
            });
        }
    }
}