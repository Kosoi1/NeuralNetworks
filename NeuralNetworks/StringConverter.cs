using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworks
{
    public class StringConverter
    {
        public double[,] Convert(string[] s)
        {
            var result = new double[s.Length, 10];
            for (int i = 0; i < s.Length; i++)
            {
                var str = Convert(s[i]);
                for (int j = 0; j < 10; j++)
                {
                    result[i, j] = str[j];
                }
            }
            return result;
        }
        public double[] Convert(string word)
        {
            var result = new List<double>();
            for (int i = 0; i < word.Length; i++)
            {
                result.Add(System.Convert.ToInt32(word[i]));
            }
            for (int i = 0; i < 10 - word.Length; i++)
            {
                result.Add(0.0);
            }
            return result.ToArray();
        }
    }
}
