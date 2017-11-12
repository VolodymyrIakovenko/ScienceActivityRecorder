using System;

namespace ScienceActivityRecorder.Providers
{
    public class ScientistProfileProvider
    {
        public static int Index
        {
            get
            {
                return 1;
            }
        }

        public static DateTime NextLastFillDate
        {
            get
            {
                return new DateTime(2017, 12, 31);
            }
        }
    }
}
