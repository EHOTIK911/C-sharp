using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTEST_F
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<char> let = new List<char>();
            List<string> list = new List<string>();
            string[] ss = Console.ReadLine().Split(' ');
            int n = int.Parse(ss[0]);
            int m = int.Parse(ss[1]);
            for(int i = 0; i < n; i++)
            {
                string s = Console.ReadLine();
                let.Add(s[0]);
                s = s.Remove(0,3);
                list.Add(s);
            }
            string sss = Console.ReadLine();
            string test = null, answ = null;

            for(int i = 0; i < sss.Length; i++)
            {
                test+= sss[i];
                if (list.Contains(test))
                {
                    int a = list.IndexOf(test);
                    answ += let[a];
                    sss.Remove(0,test.Length);
                    test = null;
                }
            }
            Console.WriteLine(answ);
            Console.ReadKey();
        }
    }
}
