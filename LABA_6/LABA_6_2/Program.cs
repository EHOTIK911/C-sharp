using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA_6_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            List<int>[] a = new List<int>[n]; // Ограниченный список
            List<string> b = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string[] strings = Console.ReadLine().Split();
                a[i] = new List<int>();
                for (int j = 0; j < strings.Length; j++)
                {
                    if (strings[j] == "1")
                    {
                        b.Add((i + 1) + " " + (j + 1));
                    }
                }
            }
            for(int i = 0; i < b.Count; i++)
            {
                Console.WriteLine(b[i]);
            }
            Console.ReadKey();
        }
    }
}
