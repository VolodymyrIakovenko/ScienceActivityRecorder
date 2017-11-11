using ScienceActivityRecorder.Models;
using System.Collections.Generic;

namespace ScienceActivityRecorder.ViewModels
{
    public class AuthorSearchResultsViewModel
    {
        public IEnumerable<AuthorSearchResult> Authors { get; set; }

        public PublicationActivity PublicationActivity { get; set; }

        public bool IsNum1 { get; set; }

        public bool IsNum2 { get; set; }
    }
}
