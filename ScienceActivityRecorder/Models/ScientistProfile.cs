namespace ScienceActivityRecorder.Models
{
    public class ScientistProfile
    {
        public PersonalInfo PersonalInfo { get; set; }

        public PublicationActivityInfo PublicationActivityInfo { get; set; }

        public ProfessionalActivityInfo ProfessionalActivityInfo { get; set; }

        public AdditionalActivityInfo AdditionalActivityInfo { get; set; }
    }
}
