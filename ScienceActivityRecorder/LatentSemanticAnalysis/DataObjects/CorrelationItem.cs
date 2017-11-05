namespace ScienceActivityRecorder.LatentSemanticAnalysis.DataObjects
{
    public class CorrelationItem
    {
        public CorrelationItem(string text, double value)
        {
            Text = text;
            Value = value;
        }

        public string Text { get; private set; }

        public double Value { get; private set; }
    }
}
