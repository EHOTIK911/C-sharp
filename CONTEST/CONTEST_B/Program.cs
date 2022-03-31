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
            string[] s = Console.ReadLine().Split(' ');
            int n = int.Parse(s[0]);
            int m = int.Parse(s[1]);
            double massa = 0,sale = 0;
            bool flag = true;
            int z = 0;
            List<double> price = new List<double>();
            List<double> value = new List<double>();
            List<double> koef = new List<double>();
            for(int i = 0; i < n; i++)
            {
                string[] ss = Console.ReadLine().Split(' ');
                price.Add(Convert.ToDouble(ss[0]));
                value.Add(Convert.ToDouble(ss[1]));

            }
            for(int i = 0; i < price.Count; i++)
            {
                koef.Add(price[i]/value[i]);
            }
            for(int i = 0; i < koef.Count; i++)
            {
                Console.WriteLine(koef[i]);
            }
            while (massa <= m)
            {
              
                int g = koef.IndexOf(koef.Max());
                massa += value[g];
                sale += price[g];
                koef.RemoveAt(g);
                if(koef.Count == 0)
                {
                    break;
                }
                z = g;
            }
            if(massa > m)
            {
                massa -= value[z];
                sale -= price[z];
                double d = 1f / value[z];
                double l = value[z];
                double p = price[z];
                sale += p / (l * d);
               
            } 
            
            Console.WriteLine("{0:0.000}",sale);
            
            Console.ReadKey();
            
        }
    
        
    }
}