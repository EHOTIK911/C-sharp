using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CONTEST_E
{
    class Program
    {
        static List<int> input()
        {
            List<int> numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToList();
            return numbers;
        }

        static void Main(string[] args)
        {
            int MinLength = 9999999, p = 0, l = 0;
            List<int> MasMin = new List<int>();List<int> MasMax = new List<int>();bool flag = true;string[] str = File.ReadAllLines(@"input.txt");str[0] = str[0].Replace(" ", String.Empty);str[0] = String.Join(" ", str[0].ToCharArray());string[] res = str[0].Split(new char[] { ' ' });string MinChar = res.Min(), MaxChar = res.Max();
            asdasdasdasdqwe(MasMin, MasMax, res, MinChar, MaxChar);

            asdasd(ref MinLength, ref p, ref l, MasMin, MasMax);

            asd(p, l, res);


        }

        private static void asdasdasdasdqwe(List<int> MasMin, List<int> MasMax, string[] res, string MinChar, string MaxChar)
        {
            for (int i = 0; i < res.Length; i++)
            {
                if (res[i] == MinChar)
                {
                    MasMin.Add(i);

                }
                if (res[i] == MaxChar)
                {
                    MasMax.Add(i);
                }

            }
        }

        private static void asdasd(ref int MinLength, ref int p, ref int l, List<int> MasMin, List<int> MasMax)
        {
            for (int i = 0; i < MasMin.Count; i++)
            {
                mjhmm(ref MinLength, ref p, ref l, MasMin, MasMax, i);
            }
        }

        private static void mjhmm(ref int MinLength, ref int p, ref int l, List<int> MasMin, List<int> MasMax, int i)
        {
            for (int n = 0; n < MasMax.Count; n++)
            {
                if (Math.Abs(MasMin[i] - MasMax[n]) < MinLength)
                {
                    MinLength = Math.Abs(MasMin[i] - MasMax[n]);
                    p = MasMin[i];
                    l = MasMax[n];
                }
            }
        }

        private static void asd(int p, int l, string[] res)
        {
            if (p <= l)
            {
                StreamWriter ew = new StreamWriter(@"output.txt");
                for (int i = p; i <= l; i++)
                {
                    ew.Write(res[i] + "");

                }
                ew.Close();
            }
            else
            {
                StreamWriter ew = new StreamWriter(@"output.txt");
                for (int i = l; i <= p; i++)
                {
                    ew.Write(res[i] + "");
                }
                ew.Close();
            }
        }
    }
}
