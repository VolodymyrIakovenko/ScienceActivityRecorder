using System.Collections.Generic;

namespace ScienceActivityRecorder.LatentSemanticAnalysis.DataObjects
{
    class Raw
    {
        public string Name { get; set; }
        public List<int> Values = new List<int>();

        public Raw(string name)
        {
            Name = name;
            Values = new List<int>();
        }

        public Raw(string name, int value)
        {
            Name = name;
            Values.Add(value);
        }
    }
}
