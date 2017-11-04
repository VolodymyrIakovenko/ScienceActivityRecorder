using ScienceActivityRecorder.Models;
using System.Collections.Generic;

namespace ScienceActivityRecorder.ViewModels
{
    public class AuthorSearchResultsViewModel
    {
        public IEnumerable<AuthorSearchResult> Authors { get; set; }
    }
}
