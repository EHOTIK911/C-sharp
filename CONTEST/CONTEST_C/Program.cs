using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTEST_C
{
    class Program
    {
        static double[] input()
        {
            double[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => double.Parse(i)).ToArray<double>();
            return numbers;
        }

        static void Main(string[] args)
        {
            double fin = 0,answer = 0;
            string[] strings = Console.ReadLine().Split(' ');
            int k = int.Parse(strings[0]);
            int R = int.Parse(strings[1]);
            double[] MAS = input();
            double SUM = 0;
            int[] List = Enumerable.Range(1, 100000).ToArray();

            for (int i = 0; i < k; i++)
            {
                SUM += MAS[i];
            }
            if(SUM > 2 * R)
            {
                
                
            }
            for (int i = 0; i < k; i++)
            {
                fin += (1 / MAS[i]) + (1 / x);
                answer += fin;
                if (Math.Round(Math.Pow(answer, -1)) == R)
                    {
                        Console.WriteLine(Math.Round(Math.Pow(answer, -1)));
                    }
                answer = 0;

            }



            Console.ReadKey();
            
        }
    }
}
