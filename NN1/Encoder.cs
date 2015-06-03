using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN1
{
    //class containing all encoding methods
    public static class Encoder
    {
        public static string EffectsEncoding(int index, int N)
        {
            if (N==2)
            {
                if (index == 0) return "-1";
                else if (index == 1) return "1";
            }

            int[] values = new int[N - 1];
            if (index == N-1) //last item is all -1s
            {
                for (int i = 0; i<values.Length; i++)
                {
                    values[i] = -1;
                }
            }
            else
            {
                values[index] = 1; //0 values are already there
            }
            string s = values[0].ToString();
            for (int i =0; i< values.Length; i++)
            {
                s += "," + values[i];
            }
            return s;
        }

        public static string DummyEncoding(int index, int N)
        {
            int[] values = new int[N];
            values[index] = 1;
            string s = values[0].ToString();
            for (int i = 0; i < values.Length; i++)
            {
                s += "," + values[i];
            }
            return s;

        }
    }
}
