using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTEST_B
{
    class Program
    {




        static void Main(string[] args)
        {



            int min = 1000;
            string[] value = Console.ReadLine().Split(' ');
            int n = int.Parse(value[0]);
            int k = int.Parse(value[1]);
            int[] a = new int[100001];
            NewMethod1(n, k, a);
            min = NewMethod(min, n, a);
            Console.WriteLine(min);
            Console.ReadKey();



        }

        private static void NewMethod1(int n, int k, int[] a)
        {
            for (int i = 0; i < n; i++)
            {
                List<int> List = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(l => int.Parse(l)).ToList();
                for (int j = 0; j < k; j++)
                {

                    a[List[j]] = a[List[j]] + 1;
                }

            }
        }

        private static int NewMethod(int min, int n, int[] a)
        {
            for (int i = 1; i < 100001; i++)
            {
                if (a[i] == n)
                {
                    min = i;
                    break;
                }
            }

            return min;
        }

        
    }
}
