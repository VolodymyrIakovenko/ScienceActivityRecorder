using ScienceActivityRecorder.LatentSemanticAnalysis.DataObjects;
using System.Collections.Generic;
using System.Linq;

namespace ScienceActivityRecorder.LatentSemanticAnalysis
{
    public class LSA
    {
        private string _keyword;
        private List<string> _texts;

        public LSA(string keyword, IEnumerable<string> textsToCompare)
        {
            _keyword = keyword;
            _texts = new List<string>(textsToCompare);
            _texts.Add(keyword);
        }

        public IEnumerable<CorrelationItem> GetCorrelations()
        {
            var list = LSAHelper.RemoveStopSymbols(_texts);
            list = LSAHelper.Stemming(list);
            var svd = LSAHelper.SVD(list);

            double[][] U;
            double[][] S;
            double[][] V;
            if (!LSAHelper.BinarySVD(svd, out U, out S, out V))
            {
                return null;
            }

            double[][] mult = LSAHelper.MultiplyMatrices(U, S, V);
            List<double> correlationValues = LSAHelper.DefineGridValues(_keyword, mult);

            List<CorrelationItem> correlations = new List<CorrelationItem>();
            for (int i = 0; i < correlationValues.Count; i++)
            {
                correlations.Add(new CorrelationItem(_texts[i], correlationValues[i]));
            }

            return correlations;
        }
    }
}
