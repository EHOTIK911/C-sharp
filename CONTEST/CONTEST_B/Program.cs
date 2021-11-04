using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTEST_B
{
    class Program
    {


        private static int binSearch_rigth(int[] a, int key)
        {
            int l = -1;
            int r = a.Length;
            while (l < r - 1)
            {
                int m = (l + r) / 2;
                if (a[m] > key)
                    r = m;
                else
                    l = m;
            }

            return l;
        }

        static void Main(string[] args)
        {

            int N = int.Parse(Console.ReadLine());
            int[] arr = input();
            int M = int.Parse(Console.ReadLine());
            int[] arr2 = input();
            for (int i = 0; i < M; i++)
            {
                Console.WriteLine(binSearch_rigth(arr, arr2[i]) - binSearch_left(arr, arr2[i]) + 1);
            }


            Console.ReadKey();



        }
        static int[] input()
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToArray<int>();
            return numbers;
        }
        private static int binSearch_left(int[] a, int key)
        {
            int l = -1;
            int r = a.Length;
            while (l < r - 1)
            {
                int m = (l + r) / 2;
                if (a[m] < key)
                    l = m;
                else
                    r = m;
            }

            return r;
        }
    }
}
