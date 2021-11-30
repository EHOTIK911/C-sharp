using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CONTEST_A
{
    class Program
    {

        static void Main(string[] _1)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n-1; i++)
            {
                for (int j = 1; j <= n-1; j++)
                {
                    string s = "" + ((i * j) / n) + ((i * j) % n) + " ";
                    if(s[0] == '0')
                    {
                        s = s.Remove(0, 1);
                    }
                    Console.Write(s);
                }
                Console.WriteLine();
            }
        }
    }
}
