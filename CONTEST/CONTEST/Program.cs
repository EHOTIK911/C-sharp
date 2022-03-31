using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CONTEST_A
{
    class Program
    {


        static void Main(string[] _1)
        {
            long n = Convert.ToInt32(Console.ReadLine());
            List<long> fib = new List<long>();
            List<long> answ = new List<long>();
            fib.Add(1);
            fib.Add(2);
            while(fib[fib.Count - 1] <= n)
            {
                fib.Add(fib[fib.Count - 1] + fib[fib.Count - 2]);
                
            }
            
            //for(int i = 0; i < fib.Count; i++)
            //{
            //    if (fib[i] < 0)
            //    {
            //        fib.RemoveAt(i);
            //    }

            //}
            fib.RemoveAt(fib.Count - 1);
            //for (int i = 0; i < fib.Count; i++)
            //{
            //    Console.Write(fib[i]+" ");
            //}
            //Console.WriteLine();
            for (int i = fib.Count-1; 0 <= i; i--)
            {
                
                
                    if (fib[i] <= n)
                    {
                        n = n - fib[i];
                        answ.Add(1);
                        fib.RemoveAt(i);
                    }
                    else
                    {
                        answ.Add(0);
                        fib.RemoveAt(i);
                    }
                
                
                  
            }
            for(int i = 0; i < answ.Count; i++)
            {
                Console.Write(answ[i]);
            }
            Console.ReadKey();
            
        }
    }
}