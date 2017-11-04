namespace ScienceActivityRecorder.GoogleScholarSearch.Utilities
{
    public class HexDecoder
    {
        public  static string Decode(string data)
        {
            data = data.Replace("\\x22", @"""");
            data = data.Replace("\\x23", "#");
            data = data.Replace("\\x24", "$");
            data = data.Replace("\\x25", "%");
            data = data.Replace("\\x26", "&");
            data = data.Replace("\\x27", "'");
            data = data.Replace("\\x28", "(");
            data = data.Replace("\\x29", ")");
            data = data.Replace("\\x2a", "*");
            data = data.Replace("\\x2b", "+");
            data = data.Replace("\\x2c", ",");
            data = data.Replace("\\x2d", "-");
            data = data.Replace("\\x2e", ".");
            data = data.Replace("\\x2f", "/");
            data = data.Replace("\\x30", "0");
            data = data.Replace("\\x31", "1");
            data = data.Replace("\\x32", "2");
            data = data.Replace("\\x33", "3");
            data = data.Replace("\\x34", "4");
            data = data.Replace("\\x35", "5");
            data = data.Replace("\\x36", "6");
            data = data.Replace("\\x37", "7");
            data = data.Replace("\\x38", "8");
            data = data.Replace("\\x39", "9");
            data = data.Replace("\\x3a", ":");
            data = data.Replace("\\x3b", ";");
            data = data.Replace("\\x3c", "<");
            data = data.Replace("\\x3d", "=");
            data = data.Replace("\\x3e", ">");
            data = data.Replace("\\x3f", "?");
            return data;
        }
    }
}
