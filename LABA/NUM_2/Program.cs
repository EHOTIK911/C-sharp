using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUM_2
{
    internal class Program
    {
        private static List<int> input()
        {
            List<int> numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToList();
            return numbers;
        }
        static void Main(string[] args)
        {
            int a = -1, b = 0, a1;
            int count_1 = 0, count_2 = 0, max_count_1 = 0, max_count_2 = 0;
            List<int> pos1 = new List<int>();
            List<int> pos2 = new List<int>();
            List<int> answer1 = new List<int>();
            List<int> answer1_check = new List<int>();
            List<int> answer2 = new List<int>();
            List<int> answer2_check = new List<int>();
            int s = Convert.ToInt32(Console.ReadLine());
            pos1 = input();
            int s1 = Convert.ToInt32(Console.ReadLine());
            pos2 = input();
            for(int i = 0; i < pos1.Count - 1; i++)
            {
                if(pos1[i] < pos1[i + 1] && i != pos1.Count-1)
                {
                    count_1++;
                    a = i;
                    if(a > b)
                    {
                        a = i;
                        b = 999999;
                    }
                }
                if(count_1 > max_count_1)
                {
                    a1 = a;
                    int f = pos2.IndexOf(pos2.Contains(pos1[a1]));
                    for(int g = a1; g < max_count_1; g++)
                    {
                        if (pos2.Contains(pos1[a1]))
                        {

                        }
                    }
                }
                //else
                //{
                //    count_1 = 0;
                //    a = -1;
                //}

                
            }
            for(int i = 0; i < answer1.Count; i++)
            {
                Console.WriteLine(answer1[i]);
            }
            Console.ReadKey();

        }
    }
}
