using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Factorization;
using MathNet.Numerics.Statistics;
using ScienceActivityRecorder.LatentSemanticAnalysis.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScienceActivityRecorder.LatentSemanticAnalysis
{
    public static class LSAHelper
    {
        public static List<string> _texts = new List<string>();
        public static List<string> _words = new List<string>();
        
        public static List<string> RemoveStopSymbols(List<string> input)
        {
            _texts.Clear();
            _texts.AddRange(input);

            List<string> stopSymbolsResultList = new List<string>();
            foreach (string name in input)
                stopSymbolsResultList.Add(string.Join(" ", name.Split().Where(w => !StopSymbols.Symbols.Contains(w))));

            return stopSymbolsResultList;
        }

        public static List<string> Stemming(List<string> stopSymbolsResultList, bool removeEmpty = true)
        {
            if (stopSymbolsResultList.Count() == 0)
                return new List<string>();

            Stemmer stemmer = new Stemmer();
            List<string> stemmingResultList = new List<string>();

            foreach (string name in stopSymbolsResultList)
            {
                List<string> wordsName = name.Split(' ', '-', '.').ToList();
                wordsName.RemoveAll(w => w.Equals("") || w.Length < 3);
                string resultString = string.Join(" ", wordsName.Select(word => stemmer.Stem(word)));

                if (!removeEmpty || !string.IsNullOrEmpty(resultString))
                    stemmingResultList.Add(resultString);
            }

            return stemmingResultList;
        }

        public static Svd<double> SVD(List<string> stemmingResultList)
        {
            if (stemmingResultList.Count() == 0)
                return null;

            List<Token> tokenList = new List<Token>();
            for (int i = 0; i < stemmingResultList.Count(); i++)
            {
                if (string.IsNullOrEmpty(stemmingResultList[i]))
                    continue;

                string[] tokens = stemmingResultList[i].Split(' ');
                for (int j = 0; j < tokens.Length; j++)
                {
                    int index = tokenList.FindIndex(t => t.Name.Equals(tokens[j]));
                    if (index < 0)
                        tokenList.Add(new Token(tokens[j], i, 1));
                    else if (tokenList[index].Documents.Keys.Contains(i))
                        tokenList[index].Documents[i]++;
                    else
                        tokenList[index].Documents.Add(i, 1);
                }
            }

            List<Raw> matrix = new List<Raw>();
            Raw raw;
            foreach (string text in stemmingResultList)
            {
                if (string.IsNullOrEmpty(text))
                    continue;

                string[] tokens = text.Split(' ');
                for (int j = 0; j < tokens.Length; j++)
                {
                    int index = tokenList.FindIndex(t => t.Name.Equals(tokens[j]));
                    if (tokenList[index].Documents.Count > 1)
                    {
                        int valueIndex = matrix.FindIndex(r => r.Name.Equals(tokenList[index].Name));
                        if (valueIndex > -1)
                            continue;

                        raw = new Raw(tokenList[index].Name);
                        for (int i = 0; i < stemmingResultList.Count; i++)
                        {
                            if (tokenList[index].Documents.Keys.Contains(i))
                                raw.Values.Add(tokenList[index].Documents[i]);
                            else
                                raw.Values.Add(0);
                        }
                        matrix.Add(raw);
                    }
                }
            }

            //double[][] array = new double[matrix.Count][];
            //for (int i = 0; i < array.Length; i++)
            //{
            //    raw = matrix[i];
            //    double[] rawArray = new double[raw.Values.Count];
            //    for (int j = 0; j < raw.Values.Count; j++)
            //        rawArray[j] = raw.Values[j];
            //    array[i] = rawArray;
            //}

            double[,] array = new double[matrix.Count, matrix.Max(r => r.Values.Count)];
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[i].Values.Count; j++)
                {
                    array[i, j] = matrix[i].Values[j];
                }
            }

            _words.Clear();
            _words.AddRange(matrix.Select(r => r.Name).ToList());

            // TEMPORARY REMOVE !!!!!!!!!!!!!!!!!!!!!!!!!
            //double[][] a = new double[][] { 
            //    new double[] { 1, 0, 0, 1, 0, 0, 0, 0, 0 },
            //    new double[] { 1, 0, 1, 0, 0, 0, 0, 0, 0 },
            //    new double[] { 1, 1, 0, 0, 0, 0, 0, 0, 0 },
            //    new double[] { 0, 1, 1, 0, 1, 0, 0, 0, 0 },
            //    new double[] { 0, 1, 1, 2, 0, 0, 0, 0, 0 },
            //    new double[] { 0, 1, 0, 0, 1, 0, 0, 0, 0 },
            //    new double[] { 0, 1, 0, 0, 1, 0, 0, 0, 0 },
            //    new double[] { 0, 0, 1, 1, 0, 0, 0, 0, 0 },
            //    new double[] { 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            //    new double[] { 0, 0, 0, 0, 0, 1, 1, 1, 0 },
            //    new double[] { 0, 0, 0, 0, 0, 0, 1, 1, 1 },
            //    new double[] { 0, 0, 0, 0, 0, 0, 0, 1, 1 }
            //};
            //--------------------------------------------------

            var denseMatrix = DenseMatrix.OfArray(array);
            var svd = denseMatrix.Svd(true);
            return svd;
        }

        public static bool BinarySVD(Svd<double> svd, out double[][] U, out double[][] S, out double[][] V)
        {
            try
            {
                var uAsArray = svd.U.ToArray();
                var uLength = svd.U.ColumnCount;
                U = new double[uLength][];
                for (int i = 0; i < uLength; i++)
                    U[i] = new double[2];

                for (int i = 0; i < uLength; i++)
                {
                    U[i][0] = uAsArray[i,0];
                    U[i][1] = uAsArray[i,1];
                }

                var wAsArray = svd.W.ToArray();
                S = new double[2][];
                S[0] = new double[2];
                S[1] = new double[2];
                S[0][0] = wAsArray[0,0];
                S[0][1] = wAsArray[0,1];
                S[1][0] = wAsArray[1,0];
                S[1][1] = wAsArray[1,1];

                //CHECK EXAMPLE !!!!!!!!!!!!!!!!
                //V = new double[svd.GetV().Array.Length][];
                //for (int i = 0; i < svd.GetV().Array.Length; i++)
                //    V[i] = new double[2];

                //for (int i = 0; i < svd.GetV().Array.Length; i++)
                //{
                //    V[i][0] = svd.GetV().Array[i][0];
                //    V[i][1] = svd.GetV().Array[i][1];
                //}

                var vAsArray = svd.VT.ToArray();
                var vLength = svd.VT.ColumnCount;
                V = new double[2][];
                for (int i = 0; i < 2; i++)
                    V[i] = new double[vLength];

                for (int i = 0; i < vLength; i++)
                {
                    V[0][i] = vAsArray[0,i];
                    V[1][i] = vAsArray[1,i];
                }
                //----------------------------------



                //TEMPOPARY REMOVE !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                //double[][] mult = MultiplyMatrices(U, S, V);
                //List<double> column1 = new List<double>();
                //List<double> column2 = new List<double>();

                //for (int i = 0; i < mult.Length; i++)
                //{
                //    column1.Add(mult[i][0]);
                //    column2.Add(mult[i][1]);
                //}
                //double correlation2 = Correlation.Spearman(column1, column2);
                //---------------------------------------------------

                return true;
            }
            catch
            {
                U = S = V = null;
                return false;
            }
        }
       
        public static double[][] MultiplyMatrices(double[][] U, double[][] S, double[][] V)
        {
            return U.MatrixProduct(S).MatrixProduct(V);
        }

        private static double[][] MatrixProduct(this double[][] matrixA, double[][] matrixB)
        {
            int aRows = matrixA.Length; 
            int aCols = matrixA[0].Length;
            int bRows = matrixB.Length; 
            int bCols = matrixB[0].Length;

            if (aCols != bRows)
                throw new Exception("Non-conformable matrices in MatrixProduct");

            double[][] result = MatrixCreate(aRows, bCols);
            for (int i = 0; i < aRows; ++i) // each row of A
                for (int j = 0; j < bCols; ++j) // each col of B
                    for (int k = 0; k < aCols; ++k)
                        result[i][j] += matrixA[i][k] * matrixB[k][j];

            return result;
        }

        private static double[][] MatrixCreate(int rows, int cols)
        {
            // creates a matrix initialized to all 0.0s  
            // do error checking here?  
            double[][] result = new double[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new double[cols];
            // auto init to 0.0  
            return result;
        }

        public static double SpearmensCorrelation(IEnumerable<double> dataA, IEnumerable<double> dataB)
        {
            return Correlation.Spearman(dataA, dataB);
        }

        public static List<double> DefineGridValues(string name, double[][] mult)
        {
            if (mult == null || mult.Length == 0)
                return null;

            int index = _texts.IndexOf(name);
            List<double> correlations = new List<double>();
            List<double> column1 = new List<double>();
            List<double> column2 = new List<double>();

            for (int i = 0; i < mult[0].Length; i++)
            {
                if (i == index)
                    continue;

                column1.Clear();
                column2.Clear();
                for (int j = 0; j < mult.Length; j++)
                {
                    column1.Add(mult[j][index]);
                    column2.Add(mult[j][i]);
                }

                correlations.Add(SpearmensCorrelation(column1, column2));
            }

            return correlations;
        }

        public static List<string> RemoveDuplicates(List<string> input, int index)
        {
            if (input.Count() == 0)
                return new List<string>();

            List<string> result = new List<string>();
            for (int i = 0; i < input.Count; i++)
            {
                if (i == index)
                {
                    result.Add(input[i]);
                    continue;
                }

                List<string> wordsName = input[i].Split(' ').ToList();
                result.Add(String.Join(" ", wordsName.Distinct()));
            }

            return result;
        }
    }
}
