using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NN1
{
    static class FileTransformer
    {
        static void EncodeFile(string originalFile, string encodedFile, int column, string encodingType)
        {
            //encodingType: "effects" or "Dummy"
            FileStream ifs = new FileStream(originalFile, FileMode.Open);
            StreamReader sr = new StreamReader(ifs);
            string line = "";
            string[] tokens = null;

            Dictionary<string, int> d = new Dictionary<string, int>();
            int itemNum = 0;
            while ((line = sr.ReadLine()) != null)
            {
                tokens = line.Split(',');
                if (d.ContainsKey(tokens[column])==false)
                {
                    d.Add(tokens[column], itemNum++);
                }
            }
            sr.Close();
            ifs.Close();

            int N = d.Count;

            ifs = new FileStream(originalFile, FileMode.Open);
            sr = new StreamReader(ifs);

            FileStream ofs = new FileStream(encodedFile, FileMode.Create);
            StreamWriter sw = new StreamWriter(ofs);
            string s = null;

            while ((line = sr.ReadLine()) != null)
            {
                s = "";
                tokens = line.Split(',');

                for (int i = 0; i<tokens.Length; i++)
                {
                    if (i==column)
                    {
                        int index = d[tokens[i]];
                        if (encodingType == "effects")
                        {
                            s += Encoder.EffectsEncoding(index, N);
                        }
                        else if (encodingType == "dummy")
                        {
                            s += Encoder.DummyEncoding(index, N);
                        }
                    }
                    else
                    {
                        s += tokens[i] + ",";
                    }
                }
                s.Remove(s.Length - 1);
                sw.WriteLine(s);
            }
            sw.Close(); ofs.Close();
            sr.Close(); ifs.Close();
        }
    }
}
