using ScienceActivityRecorder.Models;

namespace ScienceActivityRecorder.Providers
{
    public class AdditionalActivityInfoProvider
    {
        public static AdditionalActivity IakovenkoOE
        {
            get
            {
                var additionalActivityInfo = new AdditionalActivity
                {
                    Id = 1,
                    Num20VocationalGuidenceWork = "num20",
                    Num21ManagementOfCommonWork = "num21",
                    Num22CreationOfOffices = "num22",
                    Num23ParticipationInWorkOfBoards = "num23",
                    Num24NationalAward = "num24"
                };

                return additionalActivityInfo;
            }
        }
    }
}
