using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTEST_FIX_C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 1;
            double k = Convert.ToInt32(Console.ReadLine());
            double d = k;
            int I = Convert.ToInt32(Console.ReadLine());

            while(k < I)
            {
                k = k * d;
                count++;
            }
            if (k > I)
            {
                Console.WriteLine("NO");

            }
            if (k == I)
            {
                Console.WriteLine("YES");
                Console.WriteLine(count - 1);
            }
            
            Console.ReadKey();
        }
    }
}
