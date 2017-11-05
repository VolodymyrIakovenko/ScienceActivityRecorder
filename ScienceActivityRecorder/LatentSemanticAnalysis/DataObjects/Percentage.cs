namespace ScienceActivityRecorder.LatentSemanticAnalysis.DataObjects
{
    class Percentage
    {
        public string Name { get; set; }
        public double Value { get; set; }

        public Percentage(string name, double val)
        {
            Name = name;
            Value = val;
        }
    }
}
