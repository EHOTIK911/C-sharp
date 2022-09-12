using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Лаба1
{
    class Program
    {


        static void Main(string[] args)
        {
            string WB = "B";
            int count = 0;
            int n = Convert.ToInt32(Console.ReadLine());
            List<string> vs = new List<string>();
            for (int i = 0; i < n; i++)
            {
                vs.Add(Console.ReadLine());
            }

            for (int i = 0; i < vs.Count - 1; i++)
            {
                if (vs[i] != vs[i + 1])
                {
                    if (vs[i] == "W")
                    {
                        vs[i] = "B";
                        count++;
                    }
                    else
                    {
                        vs[i] = "W";
                        count++;
                    }

                }


            }
            if (vs[vs.Count - 1] == "B")
            {
                count++;
            }
            
            

            Console.WriteLine(count);
            Console.ReadKey();
        }

        



    }
}