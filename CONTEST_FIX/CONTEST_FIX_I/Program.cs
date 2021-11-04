using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTEST_FIX_I
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            while(x < 1000)
            {
                for (int i = x; i < 1000; i = i + 11+x)
                {
                    Console.Write(i + " ");
                }
                x++;
            }

            Console.ReadKey();
        }
    }
}
