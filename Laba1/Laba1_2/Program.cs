using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int max = 0;
            bool flag = true;
            int n = Convert.ToInt32(Console.ReadLine());
            string[] nn = Console.ReadLine().Split(' ');
            
            List<int> list = new List<int>();
            for (int i = 0; i < nn.Length; i++)
            {
                list.Add(int.Parse(nn[i]));
            }
            
            int m = Convert.ToInt32(Console.ReadLine());
            string[] mm = Console.ReadLine().Split(' ');
            List<int> list1 = new List<int>();
            for (int i = 0; i < mm.Length; i++)
            {
                list1.Add(int.Parse(mm[i]));
            }
            List<int> ansv = new List<int>();
            List<int> answ2 = new List<int>();
            if(n != m)
            {
                if (list.Count == Math.Min(n, m))
                {
                    for (int i = 0; i < Math.Min(n, m); i++)
                    {
                        int a = i;
                        for (int j = 0; j < Math.Max(n, m)-1; j++)
                        {
                            if (a < Math.Min(n, m)&&list[a] == list1[j])
                            {
                                ansv.Add(list[a]);
                                
                                
                            }
                            a++;

                        }


                        if (ansv.Count >= max)
                        {
                            max = ansv.Count;
                            answ2 = ansv;

                            for (int s = 0; s < max; s++)
                            {
                                answ2.Add(ansv[s]);
                            }
                            ansv.Clear();
                        }
                        else
                        {
                            ansv.Clear();
                            
                        }



                    }

                }
                else
                {
                    for (int i = 0; i < Math.Max(n, m); i++)
                    {
                        for (int j = 0; j < Math.Min(n, m); j++)
                        {
                            if (list[i] == list1[j])
                            {
                                ansv.Add(list[i]);
                            }
                        }


                        if (ansv.Count >= max)
                        {
                            max = ansv.Count;
                            answ2 = ansv;
                            ansv.Clear();
                        }
                        else
                        {
                            ansv.Clear();
                        }


                    }
                }
            }
            else
            {
                for(int i = 0; i < n; i++)
                {
                    int a = i;
                    for (int j = 0; j < n; j++)
                    {
                        if (a < n && list[a] == list1[j])
                        {
                            ansv.Add(list[a]);
                            
                        }
                        a++;

                    }


                    if (ansv.Count >= max)
                    {
                        max = ansv.Count;
                        answ2 = ansv;
                        for (int s = 0; s < max; s++)
                        {
                            Console.Write(ansv[s] + " ");
                        }
                        ansv.Clear();
                    }
                    else
                    {
                        ansv.Clear();
                    }
                }
            }

            
            
            for(int i = 0; i < answ2.Count; i++)
            {
                Console.WriteLine(answ2[i]);
            }
            Console.ReadLine();
        }
    }
}
