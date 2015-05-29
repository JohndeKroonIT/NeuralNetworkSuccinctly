using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN1
{
    static class Normalizer
    {
        /// <summary>
        /// Function that normalizes the i-th column of a matrix, by subtracting the mean and dividing by the standard deviation
        /// </summary>
        public static void GaussNormal(Matrix numericData, int i)
        {
            double mean = 0.0;
            double sqrMean = 0.0;
            for (int j = 0; j < numericData.Matrixdata.Length; j++)
            {
                mean += numericData.Matrixdata[j][i];
                sqrMean += numericData.Matrixdata[j][i] * numericData.Matrixdata[j][i];
            }
            mean /= numericData.Matrixdata.Length;
            sqrMean /= numericData.Matrixdata.Length;
            double var = sqrMean - mean * mean;
            double std = Math.Sqrt(var);

            for (int j = 0; j < numericData.Matrixdata.Length; j++)
            {
                numericData.Matrixdata[j][i] -= mean;
                numericData.Matrixdata[j][i] /= std;
            }
        }

        /// <summary>
        /// Function that normalizes the i-th of a matrix, by subtracting the minimum value and dividing by the shifted maximum value
        /// </summary>
        public static void MinMaxNormal(Matrix matrixDoubles, int column)
        {
            double min = matrixDoubles.Matrixdata[0][column];
            double max = min;
            for (int i = 0; i < matrixDoubles.Matrixdata.Length; i++)
            {
                min = Math.Min(min, matrixDoubles.Matrixdata[i][column]);
                max = Math.Max(max, matrixDoubles.Matrixdata[i][column]);
            }

            double shiftedMax = max - min;
            for (int i = 0; i < matrixDoubles.Matrixdata.Length; i++)
            {
                matrixDoubles.Matrixdata[i][column] -= min;
                matrixDoubles.Matrixdata[i][column] /= shiftedMax;
            }

        }
    }
}
