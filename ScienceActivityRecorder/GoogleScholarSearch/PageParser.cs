using HtmlAgilityPack;
using ScienceActivityRecorder.GoogleScholarSearch.Utilities;
using ScienceActivityRecorder.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ScienceActivityRecorder.GoogleScholarSearch
{
    public class PageParser
    {
        private static string AuthorSearch = "https://scholar.google.com/citations?view_op=search_authors&mauthors=\"{0}\"&hl=en";

        private static List<string> ProfilesToIgnoreWithWords = new List<string>() { "Кафедра", "Журнал" };

        public static async Task<IEnumerable<AuthorSearchResult>> GetProfilesFromAuthorSearch(string author, int maximumAmountOfProfiles)
        {
            return await GetProfilesFromAuthorSearch(author, maximumAmountOfProfiles, new List<string>());
        }

        public static async Task<IEnumerable<AuthorSearchResult>> GetProfilesFromAuthorSearch(string author, int maximumAmountOfProfiles, List<string> possibleOrganizations)
        {
            var queryLink = string.Format(AuthorSearch, author);
            return await GetProfilesFromPage(queryLink, maximumAmountOfProfiles, possibleOrganizations, 0);
        }

        private static async Task<IEnumerable<AuthorSearchResult>> GetProfilesFromPage(string queryLink, int maximumAmountOfProfiles, List<string> possibleOrganizations, int counter)
        {
            using (var client = new HttpClient())
            {
                // Get search results for the page.
                var htmlCode = await client.GetStringAsync(queryLink);
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(htmlCode);

                // Go through all search results and get their links.
                var profileLinks = new HashSet<string>();
                foreach (HtmlNode node in htmlDocument.DocumentNode.Descendants("a"))
                {
                    var link = node.GetAttributeValue("href", string.Empty);
                    if (link.Contains("/citations?user="))
                    {
                        profileLinks.Add("https://scholar.google.com" + link);
                    }
                }

                // Create a profile from each found link.
                var profiles = new List<AuthorSearchResult>();
                foreach (var profileLink in profileLinks)
                {
                    var newProfile = await GetProfileFromLink(profileLink, possibleOrganizations);
                    if (newProfile != null)
                    {
                        profiles.Add(newProfile);
                    }
                }

                // Check if there is another page with search results.
                var nextPageLink = string.Empty;
                foreach (var node in htmlDocument.DocumentNode.Descendants("button"))
                {
                    var fullLink = node.GetAttributeValue("onclick", string.Empty);
                    if (fullLink.Contains("after_author"))
                    {
                        var relativeHexLink = fullLink.Replace("window.location=", string.Empty).Replace("'", string.Empty);
                        var nextPageHexLink = "https://scholar.google.com" + relativeHexLink;
                        nextPageLink = HexDecoder.Decode(nextPageHexLink);
                    }
                }

                // Get information from all other pages recursively.
                counter += profiles.Count;
                if (!string.IsNullOrEmpty(nextPageLink) && counter < maximumAmountOfProfiles)
                {
                    foreach (var profile in await GetProfilesFromPage(nextPageLink, maximumAmountOfProfiles, possibleOrganizations, counter))
                    {
                        profiles.Add(profile);
                    }
                }

                return profiles;
            }
        }

        private static async Task<AuthorSearchResult> GetProfileFromLink(string link, List<string> possibleOrganizations)
        {
            using (var client = new HttpClient())
            {
                var htmlCode = await client.GetStringAsync(link);

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(htmlCode);

                // Parse information about the profile.
                var name = WebUtility.HtmlDecode(htmlDocument.GetElementbyId("gsc_prf_in").InnerText);
                if (ProfilesToIgnoreWithWords.Any(w => name.ToLower().Contains(w.ToLower())))
                {
                    return null;
                }

                var organizationInProfile = WebUtility.HtmlDecode(htmlDocument.DocumentNode.Descendants().Where(o => o.GetAttributeValue("class", "") == "gsc_prf_il").ElementAt(0).InnerText);
                if (possibleOrganizations.Count > 0 && !possibleOrganizations.Any(po => organizationInProfile.ToLower().Contains(po.ToLower())))
                {
                    return null;
                }

                var hIndex = htmlDocument.DocumentNode.Descendants().Where(o => o.GetAttributeValue("class", "") == "gsc_rsb_std").ElementAt(2).InnerText;

                var field = string.Empty;
                var fieldNodes = htmlDocument.DocumentNode.Descendants().Where(o => o.GetAttributeValue("class", "") == "gsc_prf_ila");
                if (fieldNodes != null)
                {
                    for (var i = 0; i < fieldNodes.Count(); i++)
                    {
                        field += WebUtility.HtmlDecode(fieldNodes.ElementAt(i).InnerText);
                        if (i != fieldNodes.Count() - 1)
                        {
                            field += ", ";
                        }
                    }
                }

                var publicationNodes = htmlDocument.DocumentNode.Descendants().Where(o => o.GetAttributeValue("class", "") == "gsc_a_at");
                var publications = publicationNodes.Select(p =>
                {
                    var text = WebUtility.HtmlDecode(p.InnerText);

                    int index = text.IndexOf(" doi");
                    if (index == -1)
                    {
                        index = text.IndexOf(" dx.doi");
                        if (index == -1)
                        {
                            return text.Trim();
                        }
                    }

                    return text.Substring(0, index).Replace("=", "").Trim();
                });

                return new AuthorSearchResult
                {
                    NameSurname = name,
                    HIndex = int.Parse(hIndex),
                    Organization = organizationInProfile,
                    Field = field,
                    Link = link,
                    Publications = publications
                };
            }
        }
    }
}
