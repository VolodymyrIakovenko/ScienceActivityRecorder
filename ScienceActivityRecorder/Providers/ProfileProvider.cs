using ScienceActivityRecorder.Models;

namespace ScienceActivityRecorder.Providers
{
    public class ProfileProvider
    {
        public static Profile IakovenkoOE
        {
            get
            {
                var profile = new Profile
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
