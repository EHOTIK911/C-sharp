using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TEST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using (StreamReader re = new StreamReader());
            string[] ss = File.ReadAllLines("input.txt");
            int s = int.Parse(ss[0]);
            int[,] a = new int[s, s];
            for (int i = 1; i < ss.Length; i++)
            {
                string[] sss = ss[i].Split(' ');
                for (int g = 0; g < s; g++)
                {
                    a[i-1, g] = int.Parse(sss[g]);
                }
            }
            Console.WriteLine();
            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < s; j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
