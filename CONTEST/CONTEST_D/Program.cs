using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace CONTEST_D
{

    class Program
    {
   
        static void Main(string[] _TEST)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            bool flag = true;
            List<string> list = new List<string>();
            for(int i = 0; i < n; i++)
            {
                list.Add(Console.ReadLine());
            }
            list.RemoveAll(EndsWithSaurus);
            list.Insert(0, " ");
            while (flag)
            {
                for(int i = 0; i < list.Count; i++)
                {
                    if(list[i][0].ToString() == "*")
                    {
                        string s = list[i];
                        list.RemoveAt(i);
                        if(i%2 == 0)
                        {
                            list.Insert(i/2,s);
                        }
                        else
                        {
                            list.Insert(i / 2+1, s);
                        }
                        
                    }
                }
               // string del = "-";
                
                //for(int i = 0; i < list.Count; i++)
                //{
                //    if(list[i][0].ToString() == "-")
                //    {
                //        list.RemoveAt(i);
                //    }

                //}
                for (int i = 0; i < list.Count; i++)
                {
                    
                    if (list[i][0].ToString() == "+" || list[i][0].ToString() == "*")
                    {
                        list[i] = list[i].Remove(0, 2);
                    }
                }
                flag = false;
            }
            list.RemoveAt(0);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            Console.ReadKey();



        }
        private static bool EndsWithSaurus(String s)
        {
            return s.ToLower().EndsWith("-");
        }


    }
}

