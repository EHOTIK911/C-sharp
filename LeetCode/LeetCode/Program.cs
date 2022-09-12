using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            int count_1 = 0; // (
            int count_2 = 0; // )
            int count_3 = 0; // [
            int count_4 = 0; // ]
            int count_5 = 0; // {
            int count_6 = 0; // }
            bool flag = false;

            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == '(')
                {
                    count_1++;
                    if (s[i + 1] == ')')
                    {
                        count_1++;
                    }
                }
                else if (s[i] == '[')
                {
                    count_2++;
                    if (s[i + 1] == ']')
                    {
                        count_2++;
                    }
                }

                else if (s[i] == '{')
                {
                    count_3++;
                    if (s[i + 1] == '}')
                    {
                        count_3++;
                    }
                }
                
                if (count_1 % == 0 || count_2 % 2 == 0 || count_3 % 2 == 0) flag = true;

            }
            return flag;
            Console.ReadKey();
        }
    }
}
