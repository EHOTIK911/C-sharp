using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace CONTEST_D
{

    class Program
    {

        static void Main(string[] _TEST)
        {
            List<int> check = new List<int>();
            string[] str = File.ReadAllLines(@"input.txt");
            int n = Convert.ToInt32(str[0]);
            int[,] mas = new int[n, n];
            Random rnd = new Random();
            int p = 0, d;
            int max = 0;
            for (int s = 1; s < str.Length; s++)
            {
                string[] srt2 = str[s].Split(' ');
                for (int j = 0; j < n; j++)
                {
                    mas[p, j] = Convert.ToInt32(srt2[j].ToString());
                    if (mas[p, j] > max)
                    {
                        max = mas[p, j];
                    }
                    if (mas[p, j] != 0)
                    {
                        check.Add(mas[p, j]);
                    }
                }
                p++;
            }
            StreamWriter re = new StreamWriter("output.txt");
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; j++)
                {
                    if (mas[i, j] == 0)
                    {
                        d = rnd.Next(1, max * max);
                        while (check.Contains(d))
                        {
                            d = rnd.Next(1, max * max);
                        }
                        mas[i, j] = d;
                        check.Add(d);
                    }
                    re.Write(mas[i, j] + " ");
                }
                re.WriteLine();
            }
            re.Close();
            
            Console.ReadKey();

        }
    }
}

