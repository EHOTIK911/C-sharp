using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _TEST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] s = Console.ReadLine().Trim().Split(' ');
            int n = int.Parse(s[0]);
            int m = int.Parse(s[1]);
            int[] masA = new int[n + 1];
            int[] masB = new int[m + 1];
            string[,] z = new string[n + 1, m + 1];
            for (int i = 0; i < n + 1; i++)
                for (int j = 0; j < m + 1; j++)
                    z[i, j] = "-1";
            string[] ss = Console.ReadLine().Trim().Split(' ');
            for (int i = 1; i < n + 1; i++)
                masA[i] = int.Parse(ss[i - 1]);
            ss = Console.ReadLine().Trim().Split(' ');
            for (int i = 1; i < m + 1; i++)
                masB[i] = int.Parse(ss[i - 1]);
            string rez = calcZ(n, m, z, masA, masB);
            List<string> rezz = new List<string>();
            for (int i = 0; i < rez.Length; i++)
            {
                rezz.Add(rez[i].ToString());
            }

            var rezz1 = rezz.Distinct();
            foreach (string age in rezz1)
            {
                Console.Write(age + " ");
            }
            
            Console.ReadKey();
        }
        static string calcZ(int i, int j, string[,] z, int[] masA, int[] masB)
        {
            if (z[i, j] != "-1") return z[i, j];

            if (i == 0 || j == 0)
                z[i, j] = "0";
            else
            {
                if (masA[i] == masB[j])
                {
                    z[i, j] = calcZ(i - 1, j - 1, z, masA, masB) + 1;
                }

                else
                {
                    z[i, j] = Math.Max(int.Parse(calcZ(i - 1, j, z, masA, masB)), int.Parse(calcZ(i, j - 1, z, masA, masB))).ToString();
                }
                z[i, j] += masA[i].ToString();

            }
            return z[i, j];
        }
    }
}
