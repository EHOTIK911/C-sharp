using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TASK_2
{
    class Program
    {
        static int fib(int n)
        {
            return n > 1 ? fib(n - 1) + fib(n - 2) : n;
        }
        static void Main(string[] args)
        {
            int count = 0, ans = 0;
            bool flag = true;
            List<int> list = new List<int>();
            List<int> answ = new List<int>();
            string[] n = Console.ReadLine().Split(' ');
            int b = int.Parse(n[0]);
            for (int i = 1; i < n.Length; i++)
            {
                list.Add(int.Parse(n[i]));
            }
            int d = 0;
            while (flag)
            {
                d = 0;
                for (int i = 0; i < list.Count - 2; i++)
                {

                    
                    if (list[i] == list[i + 1] && list[i] == list[i + 2])
                    {
                        int r = i;
                        while (i != list.Count-1 && list.Count > 1  && list[i] == list[i + 1])
                        {
                            list.RemoveAt(i+1);
                            ans++;
                            d = 1;

                        }
                        list.RemoveAt(r);
                        ans++;
                    }

                }
                count++;

                if(d == 0)
                {
                    flag = false;
                }
            }
            
            Console.WriteLine(ans);
            
            
        }

       
    }
}
