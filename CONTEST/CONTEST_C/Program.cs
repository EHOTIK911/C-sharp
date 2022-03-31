using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CONTEST_C
{
    class Program
    {
        static void Main(string[] _1)
        {
            string [] s = Console.ReadLine().Split(' ');
            int S = int.Parse(s[0]);
            int K = int.Parse(s[1]);
            List<int> list = new List<int>();
            int u = 0; 
            string o = null;
            for(int i = 9; i > 0; i--)
            {
                
                int n = S / i;
                for(int j = 1; j <= n; j++)
                {
                    
                    int d = (u + j);
                    list.Add(d);
                    u = 0;
                    o +=list.Max().ToString();

                }
                
                S = S % i;
                if(S == 0)
                {
                    break;
                }
            }
            Console.WriteLine(o);
            //for(int i = 0; i < K; i++)
            //{
            //    Console.Write(list[i]);
            //}
            Console.ReadKey();
        }

        
    }
}
