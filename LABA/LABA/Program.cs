using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 1, a = 0;
            List<string> Blin = new List<string>();
            int N = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < N; i++)
            {
                string s = Console.ReadLine();
                Blin.Add(s);
            }
            for(int i = 0; i < Blin.Count; i++)
            {
                if(Blin[i] == "W" && i != Blin.Count - 1)
                {
                    if (Blin[i + 1] != "W")
                    {
                        count++;

                    }
                    else
                        continue;

                }
                if (Blin[i] == "B" && i != Blin.Count - 1)
                {
                    if (Blin[i + 1] != "B")
                    {
                        count++;
                    }
                    else
                        continue;


                }


            }
            //if(Blin[Blin.Count-1] != Blin[Blin.Count - 2])
            //{
            //    a = 1;
            //}
            Console.WriteLine(count);
            //for(int i = 0; i < Blin.Count; i++)
            //{
            //    Console.WriteLine(Blin[i]);
            //}
            Console.ReadKey();
        }
    }
}
