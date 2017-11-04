using HtmlAgilityPack;
using ScienceActivityRecorder.GoogleScholarSearch.Utilities;
using ScienceActivityRecorder.Models;
using System;
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

                var publications = new List<Publication>();
                var publicationsBodyNode = htmlDocument.DocumentNode.SelectSingleNode("//tbody[@id='gsc_a_b']");
                if (publicationsBodyNode != null)
                {
                    foreach (var publicationNode in publicationsBodyNode.ChildNodes)
                    {
                        var publication = new Publication();
                        
                        var publicationNameNode = publicationNode.ChildNodes[0];
                        if (publicationNameNode != null && publicationNameNode.ChildNodes.Count >= 3)
                        {

                            var publicationName = WebUtility.HtmlDecode(publicationNameNode.ChildNodes[0].InnerText);
                            var index1 = publicationName.IndexOf(" doi");
                            var index2 = publicationName.IndexOf(" dx.doi");
                            if (index1 >= 0)
                            {
                                publication.Name = publicationName.Substring(0, index1).Replace("=", "").Trim();
                            }
                            else if (index2 >= 0)
                            {
                                publication.Name = publicationName.Substring(0, index2).Replace("=", "").Trim();
                            }
                            else
                            {
                                publication.Name = publicationName.Trim();
                            }

                            publication.Authors = WebUtility.HtmlDecode(publicationNameNode.ChildNodes[1].InnerText);
                            publication.Journal = WebUtility.HtmlDecode(publicationNameNode.ChildNodes[2].InnerText);
                        }

                        var publicationYearNode = publicationNode.ChildNodes[2];
                        if (publicationYearNode != null)
                        {
                            Int32.TryParse(publicationYearNode.InnerText, out int year);
                            publication.Year = year;
                        }

                        publications.Add(publication);
                    }
                }

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
