using System.Collections.Generic;

namespace ScienceActivityRecorder.Models
{
    public class Organization
    {
        public Organization(string name)
            : this(name, new List<string>())
        {
        }

        public Organization(string name, List<string> alternativeNames)
        {
            Name = name;
            AlternativeNames = alternativeNames;
        }

        public string Name { get; set; }

        public List<string> AlternativeNames { get; set; }
    }
}
