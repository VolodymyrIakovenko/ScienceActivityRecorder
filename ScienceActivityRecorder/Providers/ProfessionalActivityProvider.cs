using ScienceActivityRecorder.Models;

namespace ScienceActivityRecorder.Providers
{
    public class ProfessionalActivityProvider
    {
        public static ProfessionalActivityInfo IakovenkoOE
        {
            get
            {
                var professionalActivityInfo = new ProfessionalActivityInfo
                {
                    Id = 1,
                    Num4ScientificManagement = "num4",
                    Num5ParticipationInInternationalProjects = "num5",
                    Num6LecturesInForeignLanguage = "num6",
                    Num7WorkInExpertBoard = "num7",
                    Num8ScientificGuidenceFunctions = "num8",
                    Num9MangementOfPriceWinnerStudent = "num9",
                    Num10OrganizationalWorkInEducationalInstitutions = "num10",
                    Num11ParticipationInValidationOfScientists = "num11",
                    Num12DegreeOfDoctor = "num12",
                    Num13PatentsAvailibility = "num13",
                    Num15DegreeOfDoctorOfPhilosophy = "num15",
                    Num16ManagementOfUkrainianOlympicWinnerStudent = "num16",
                    Num17OrganizingSocialActivities = "num17",
                    Num19CombinationOfTeachingAndPractice = "num19"
                };

                return professionalActivityInfo;
            }
        }
    }
}
