using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace TEST1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            var array = new int[] { 1, 2, 2, 1, 3 , 7, 5, 4, 3, 9, 7, 6, 5, 3, 8 };
            int d = array.Length;
            var result = array.Distinct().ToArray();
            List<int> list = result.ToList();
            
            while(list.Count <= d)
            {
                list.Add(rnd.Next(1,10));
                d--;
            }
            for(int g = 0; g < list.Count; g++)
            {
                for(int i = 0; i < list.Count; i++)
                {
                    if (list[g] == list[i])
                    {
                        list[g] = rnd.Next(1, 10);
                    }
                }
                
                
            }
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine(list[i]);
            Console.ReadKey();

        }
    }
}
