using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTEST_FIX_N
{
    internal class Program
    {
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
        private static List<int> input()
        {
            List<int> numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToList();
            return numbers;
        }
        static void Main(string[] args)
        {
            input();
            List<int> MAS1 = input();
            input();
            List<int> MAS2 = input();
            for(int i = 0;i < MAS2.Count; i++)
            {
                Console.WriteLine(BinarySearch1(MAS1,MAS2[i]));
            }
            Console.ReadKey();
        }
    }
}
