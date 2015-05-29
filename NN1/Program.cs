using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nBegin data encoding and normalization demo\n");
            string[] sourceData= new string[] {"Sex Age Locale Income Politics",
                                                "==============================================",
                                                "Male 25 Rural 63,000.00 Conservative",
                                                "Female 36 Suburban 55,000.00 Liberal",
                                                "Male 40 Urban 74,000.00 Moderate",
                                                "Female 23 Rural 28,000.00 Liberal"};
            Console.WriteLine("\nDummy data in raw form:\n");
            ShowData(sourceData);

            string[] encodedData = new string[] {
                "-1 25 1 0 63,000.00 1 0 0",
                " 1 36 0 1 55,000.00 0 1 0",
                "-1 40 -1 -1 74,000.00 0 0 1",
                " 1 23 1 0 28,000.00 0 1 0" };

            Console.WriteLine("\nData after categorical encoding:\n");
            ShowData(encodedData);

            Console.WriteLine("\nNumeric data stored in matrix:\n");
            var numericData = new Matrix(4);
            numericData.AddRow(new [] { -1, 25.0, 1, 0, 63000.00, 1, 0, 0 },0);
            numericData.AddRow(new [] { 1, 36.0, 0, 1, 55000.00, 0, 1, 0 },1);
            numericData.AddRow(new [] { -1, 40.0, -1, -1, 74000.00, 0, 0, 1 },2);
            numericData.AddRow(new [] { 1, 23.0, 1, 0, 28000.00, 0, 1, 0 },3);
            numericData.ShowMatrix(2);

            Normalizer.GaussNormal(numericData, 1);
            Normalizer.MinMaxNormal(numericData, 4);

            Console.WriteLine("\nMatrix after normalization (Gaussian col. 1 and MinMax col. 4):\n");
            numericData.ShowMatrix(2);

            Console.WriteLine("\nEnd data encoding and normalization demo\n"); 
            Console.ReadLine();
        }

        
        private static void ShowData(string[] rawData)
        {
            for (int i = 0; i < rawData.Length; i++)
            {
                Console.WriteLine(rawData[i]);
                Console.WriteLine("");
            }
        }
    }
}
