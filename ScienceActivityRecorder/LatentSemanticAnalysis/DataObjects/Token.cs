using System.Collections.Generic;

namespace ScienceActivityRecorder.LatentSemanticAnalysis.DataObjects
{
    class Token
    {
        public string Name { get; set; }
        public Dictionary<int, int> Documents = new Dictionary<int, int>();

        public Token(string name, int document, int amount)
        {
            Name = name;
            Documents.Add(document, amount);
        }
    }
}
