using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN1
{
    public class Matrix
    {
        public double[][] Matrixdata;

        /// <summary>
        /// public constructor that uses only number of rows
        /// </summary>
        public Matrix(int numberOfRows)
        {
            Matrixdata = new double[numberOfRows][];
        }

        /// <summary>
        /// Adds a row to the matrix
        /// </summary>
        public void AddRow(double[] rowData, int rowNumber)
        {
            Matrixdata[rowNumber] = rowData;
        }

        /// <summary>
        /// Prints the content of the matrix in the memory
        /// </summary>
        public void ShowMatrix(int decimals)
        {
            for (int i = 0; i < Matrixdata.Length; ++i)
            {
                for (int j = 0; j < Matrixdata[i].Length; ++j)
                {
                    double v = Math.Abs(Matrixdata[i][j]);
                    if (Matrixdata[i][j] >= 0.0)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("-");
                    }
                    Console.Write(v.ToString("F" + decimals).PadRight(5) + " ");
                }
                Console.WriteLine("");
            }
        }
    }
}
