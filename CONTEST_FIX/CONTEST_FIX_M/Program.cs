using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTEST_FIX_M
{
    internal class Program
    {
        private static List<int> input()
        {
            List<int> numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToList();
            return numbers;
        }
        private static int BinarySearch1(List<int> arr, int el)
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
            string[] NUM = Console.ReadLine().Split(' ');
            int n = int.Parse(NUM[0]);
            int l = int.Parse(NUM[1]);
            List<int> arr = input();
            arr.Sort();
            int s = 0;
            while(arr[s] <= l)
            {
                arr.RemoveAt(s);
            }
            Console.WriteLine(arr.Sum());
            Console.ReadKey();
        }
    }
}
