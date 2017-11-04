using ScienceActivityRecorder.Models;

namespace ScienceActivityRecorder.Providers
{
    public class ScientistProfileProvider
    {
        public static ScientistProfile IakovenkoOE
        {
            get
            {
                var profile = new ScientistProfile
                {
                    PersonalInfo = PersonalInfoProvider.IakovenkoOE,
                    PublicationActivityInfo = PublicationActivityInfoProvider.IakovenkoOE,
                    ProfessionalActivityInfo = ProfessionalActivityProvider.IakovenkoOE,
                    AdditionalActivityInfo = AdditionalActivityInfoProvider.IakovenkoOE
                };

                return profile;
            }
        }
    }
}
