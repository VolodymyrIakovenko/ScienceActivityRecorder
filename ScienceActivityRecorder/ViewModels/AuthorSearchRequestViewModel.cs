using ScienceActivityRecorder.Models;
using ScienceActivityRecorder.Providers;
using System.Collections.Generic;

namespace ScienceActivityRecorder.ViewModels
{
    public class AuthorSearchRequestViewModel
    {
        public AuthorSearchRequest AuthorSearchRequest { get; set; }

        public List<Organization> PredefinedOrganizations { get { return OrganizationProvider.PredefinedOrganizations; } }

        public PublicationActivity PublicationActivity { get; set; }

        public bool IsNum1 { get; set; }

        public bool IsNum2 { get; set; }
    }
}
