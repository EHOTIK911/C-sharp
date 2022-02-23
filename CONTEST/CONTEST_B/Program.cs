using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace CONTEST_B
{
    class Program
    {
        static void Main(string[] args)
        {
            int ansver = 0, ansver_2 = 0;
            string s = Console.ReadLine();
            for(int i = 0; i < s.Length; i+= 2)
            {
                ansver += int.Parse(s[i].ToString());
            }
            for(int i = 1; i < s.Length; i += 2)
            {
                ansver_2 += int.Parse(s[i].ToString());
            }
            if(ansver + ansver_2 * 3 == 90)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

            
        }
    
        
    }
}