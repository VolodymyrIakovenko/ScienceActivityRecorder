﻿using ScienceActivityRecorder.Models;

namespace ScienceActivityRecorder.Providers
{
    public class AdditionalActivityInfoProvider
    {
        public static AdditionalActivityInfo IakovenkoOE
        {
            get
            {
                var additionalActivityInfo = new AdditionalActivityInfo
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