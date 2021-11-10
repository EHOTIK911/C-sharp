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

            bool flag = true;
            int max = 0;
            int test = 0;
            int f = Convert.ToInt32(Console.ReadLine());
            int[] MAS = input();
            int[] CT = new int[MAS.Max()];
            TEST1(CT);
            TEST2(MAS, CT);
            flag = PRINT_TRUE(flag, f, CT);
            if (flag == true)
                Console.WriteLine(0);
            Console.ReadKey();
        }

        private static bool PRINT_TRUE(bool flag, int f, int[] CT)
        {
            for (int i = 0; CT.Length > i; i++)
            {
                if (CT[i] > f / 2f)
                {
                    flag = false;
                    Console.WriteLine(i + 1 + " ");
                }
            }

            return flag;
        }

        private static void TEST2(int[] MAS, int[] CT)
        {
            for (int i = 0; i < MAS.Length; i++)
                CT[MAS[i] - 1] = CT[MAS[i] - 1] + 1;
        }

        private static void TEST1(int[] CT)
        {
            for (int i = 0; i < CT.Length; i++)
                CT[i] = 0;
        }
    }
}
