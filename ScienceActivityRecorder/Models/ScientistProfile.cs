namespace ScienceActivityRecorder.Models
{
    public class ScientistProfile
    {
        public Profile PersonalInfo { get; set; }

        public PublicationActivity PublicationActivityInfo { get; set; }

        public ProfessionalActivity ProfessionalActivityInfo { get; set; }

        public AdditionalActivity AdditionalActivityInfo { get; set; }
    }
}
