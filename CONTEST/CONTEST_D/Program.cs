/*Чистяков Евгений Михайлович Номер 2 Добавить к максимальной серии ещё 1 элемент номер 14
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace контест2
{

    class Program
    {
        // N - Колво проводников 
        // С - итоговое сопр
        static List<float> input()
        {
            List<float> mas = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => float.Parse(i)).ToList();
            return mas;
        }
        private static int BinarySearch(List<int> arr, int el)
        {
            int l = 0, r = arr.Count - 1, middle = (1 + r) / 2;
            while (l <= r)
            {
                if (arr[middle] > el)
                    r = middle - 1;
                if (arr[middle] < el)
                    l = middle + 1;
                if (arr[middle] == el)
                    return middle;
                middle = (l + r) / 2;
            }
            return -1;
        }

        static void Main(string[] args)
        {
            bool flag = true;
            float sum = 0;
            float x = 0.5f;
            int mn = 1;
            string[] soord = Console.ReadLine().Split(' ');
            int N = int.Parse(soord[0]);
            int C = int.Parse(soord[1]);
            List<float> arr = input();
            while (sum < C)
            {
                x = x * 2;
                sum = 0;
                for (int i = 0; i < arr.Count; i++)
                {
                    sum = sum + (x * arr[i]) / (x + arr[i]);
                }

            }
            while (sum > C)
            {
                sum = 0;
                x = x - 1;
                for (int i = 0; i < arr.Count; i++)
                {
                    sum = sum + (x * arr[i]) / (x + arr[i]);
                }
                if (sum == C)
                {
                    flag = false;
                    Console.WriteLine(x+".000000" + " " + sum);
                }
            }
            if (flag == true)
            {
                Console.WriteLine(x + ".000000" + " " + sum);
            }

            Console.ReadKey();

        }

    }
}

