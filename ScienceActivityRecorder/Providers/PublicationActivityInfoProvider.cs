using ScienceActivityRecorder.Models;

namespace ScienceActivityRecorder.Providers
{
    public class PublicationActivityInfoProvider
    {
        public static PublicationActivity IakovenkoOE
        {
            get
            {
                var publicationActivityInfo = new PublicationActivity
                {
                    Id = 1,
                    Num1PublicationsInScienceMetricDatabases = "num1",
                    Num2PublicationsInUkrainianDatabases = "num2",
                    Num3TextbookAvailability = "num3",
                    Num14TeachingManualsAvailibility = "num14",
                    Num18PopularSciencePublicationsAvailibility = "num18"
                };

                return publicationActivityInfo;
            }
        }
    }
}
