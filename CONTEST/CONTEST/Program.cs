using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTEST_A
{
    internal class Program
    {
        static int[] input()
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToArray<int>();
            return numbers;
        }
        static void Main(string[] args)
        {
            int count = 0;
            int max = 0;
            int test = 0;
            int f = Convert.ToInt32(Console.ReadLine());
            int[] MAS = input();
            for(int i = 0; i < MAS.Length-1; i++)
            {
                count = 0;
                for (int g = 0; g < MAS.Length - 1; g++)
                {
                    if(MAS[i] == MAS[g])
                    {
                        count++;
                    }

                }
                if (count > max) 
                {
                    max = count;
                    test = MAS[i];
                }
                

            }

            if(max == 1)
            {
                test = 0;
            }

            Console.WriteLine(test);
            Console.ReadKey();
        }

    }
}
