using DocumentFormat.OpenXml.Packaging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OpenXmlPowerTools;
using ScienceActivityRecorder.Models;
using ScienceActivityRecorder.Providers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ScienceActivityRecorder.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        private const string GeneratedReportsFolder = "GeneratedReports";
        private const string TemplateLicenseTermsDocName = "TemplateLicenseTerms.docx";
        private const string TemplateAdditionalActivityDocName = "TemplateAdditionalActivity.docx";

        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly string _webRootFolder;
        private readonly string _templateLicenseTermsPath;
        private readonly string _templateAdditionalActivityPath;

        public ReportsController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;

            _webRootFolder = _hostingEnvironment.WebRootPath;

            var templateLicenseTermsVirtualPath = Path.Combine(GeneratedReportsFolder, TemplateLicenseTermsDocName);
            _templateLicenseTermsPath = Path.Combine(_webRootFolder, templateLicenseTermsVirtualPath);

            var templateAdditionalActivityVirtualPath = Path.Combine(GeneratedReportsFolder, TemplateAdditionalActivityDocName);
            _templateAdditionalActivityPath = Path.Combine(_webRootFolder, templateAdditionalActivityVirtualPath);

            // Remove unnecessary keys from xml code in the templates.
            var settings = new SimplifyMarkupSettings
            {
                RemoveComments = true,
                RemoveContentControls = true,
                RemoveEndAndFootNotes = true,
                RemoveFieldCodes = false,
                RemoveLastRenderedPageBreak = true,
                RemovePermissions = true,
                RemoveProof = true,
                RemoveRsidInfo = true,
                RemoveSmartTags = true,
                RemoveSoftHyphens = true,
                ReplaceTabsWithSpaces = true,
                RemoveBookmarks = true
            };

            using (var doc = WordprocessingDocument.Open(_templateLicenseTermsPath, true))
            {
                MarkupSimplifier.SimplifyMarkup(doc, settings);
            }

            using (var doc = WordprocessingDocument.Open(_templateAdditionalActivityPath, true))
            {
                MarkupSimplifier.SimplifyMarkup(doc, settings);
            }
        }

        public IActionResult GenerateLicenseTerms()
        {
            var profile = ViewBag.Profile as Profile;
            var replacementStrings = GetReplacementStrings(profile);

            var fileName = profile.LastName + " " + profile.FirstName + " " + profile.MiddleName + " (ліцензійні умови).docx";
            var virtualPath = Path.Combine(GeneratedReportsFolder, fileName);
            var file = new FileInfo(Path.Combine(_webRootFolder, virtualPath));

            System.IO.File.Copy(_templateLicenseTermsPath, file.FullName, true);
            SearchAndReplace(file.FullName, replacementStrings);
            
            return File(virtualPath, "application/docx", file.Name);
        }

        public IActionResult GenerateAdditionalActivity()
        {
            var profile = ViewBag.Profile as Profile;
            var replacementStrings = GetReplacementStrings(profile);

            var fileName = profile.LastName + " " + profile.FirstName + " " + profile.MiddleName + " (додаткова діяльність).docx";
            var virtualPath = Path.Combine(GeneratedReportsFolder, fileName);
            var file = new FileInfo(Path.Combine(_webRootFolder, virtualPath));

            System.IO.File.Copy(_templateAdditionalActivityPath, file.FullName, true);
            SearchAndReplace(file.FullName, replacementStrings);

            return File(virtualPath, "application/docx", file.Name);
        }

        public IActionResult Visualize()
        {
            return View();
        }

        private static void SearchAndReplace(string document, Dictionary<string, string> replacementStrings)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(document, true))
            {
                string docText = null;
                using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }

                foreach (var key in replacementStrings.Keys)
                {
                    docText = docText.Replace(key, replacementStrings[key]);
                }

                using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }
            }
        }

        private Dictionary<string, string> GetReplacementStrings(Profile profile)
        {
            var publicationActivity = profile.PublicationActivity.FirstOrDefault(p => p.LastFillDate == ProfileProvider.NextLastFillDate);
            var professionalActivity = profile.ProfessionalActivity.FirstOrDefault(p => p.LastFillDate == ProfileProvider.NextLastFillDate);
            var additionalActivity = profile.AdditionalActivity.FirstOrDefault(p => p.LastFillDate == ProfileProvider.NextLastFillDate);

            var replacementStrings = new Dictionary<string, string>
            {
                { "!LastName!", profile.LastName ?? string.Empty },
                { "!FirstName!", profile.FirstName ?? string.Empty },
                { "!MiddleName!", profile.MiddleName ?? string.Empty },
                { "!SignatureName!", (profile.LastName ?? profile.LastName) + " " + (profile.FirstName == null ? string.Empty : profile.FirstName[0].ToString()) + "." + (profile.MiddleName == null ? string.Empty : profile.MiddleName[0].ToString()) + "." },
                { "!StartDate!", ProfileProvider.NextLastFillDate.AddMonths(-6).ToString("dd.MM.yyyy") },
                { "!EndDate!", ProfileProvider.NextLastFillDate.ToString("dd.MM.yyyy") },
                { "!Num1!", publicationActivity.Num1PublicationsInScienceMetricDatabases ?? string.Empty },
                { "!Num2!", publicationActivity.Num2PublicationsInUkrainianDatabases ?? string.Empty },
                { "!Num3!", publicationActivity.Num3TextbookAvailability ?? string.Empty },
                { "!Num4!", professionalActivity.Num4ScientificManagement ?? string.Empty },
                { "!Num5!", professionalActivity.Num5ParticipationInInternationalProjects ?? string.Empty },
                { "!Num6!", professionalActivity.Num6LecturesInForeignLanguage ?? string.Empty },
                { "!Num7!", professionalActivity.Num7WorkInExpertBoard ?? string.Empty },
                { "!Num8!", professionalActivity.Num8ScientificGuidenceFunctions ?? string.Empty },
                { "!Num9!", professionalActivity.Num9MangementOfPriceWinnerStudent ?? string.Empty },
                { "!Num10!", professionalActivity.Num10OrganizationalWorkInEducationalInstitutions ?? string.Empty },
                { "!Num11!", professionalActivity.Num11ParticipationInValidationOfScientists ?? string.Empty },
                { "!Num12!", professionalActivity.Num12DegreeOfDoctor ?? string.Empty },
                { "!Num13!", professionalActivity.Num13PatentsAvailibility ?? string.Empty },
                { "!Num14!", publicationActivity.Num14TeachingManualsAvailibility ?? string.Empty },
                { "!Num15!", professionalActivity.Num15DegreeOfDoctorOfPhilosophy ?? string.Empty },
                { "!Num16!", professionalActivity.Num16ManagementOfUkrainianOlympicWinnerStudent ?? string.Empty },
                { "!Num17!", professionalActivity.Num17OrganizingSocialActivities ?? string.Empty },
                { "!Num18!", publicationActivity.Num18PopularSciencePublicationsAvailibility ?? string.Empty },
                { "!Num19!", professionalActivity.Num19CombinationOfTeachingAndPractice ?? string.Empty },
                { "!Num20!", additionalActivity.Num20VocationalGuidenceWork ?? string.Empty },
                { "!Num21!", additionalActivity.Num21ManagementOfCommonWork ?? string.Empty },
                { "!Num22!", additionalActivity.Num22CreationOfOffices ?? string.Empty },
                { "!Num23!", additionalActivity.Num23ParticipationInWorkOfBoards ?? string.Empty },
                { "!Num24!", additionalActivity.Num24NationalAward ?? string.Empty },
            };

            return replacementStrings;
        }
    }
}