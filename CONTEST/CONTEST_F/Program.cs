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
            string[] M = Console.ReadLine().Split(' ');
            int S = int.Parse(M[0]);
            int p = int.Parse(M[1]);

            Console.WriteLine(BASE(S,p));
            Console.ReadKey();
        }
        static int BASE(int _1, int _2)
        {
            if (_2 > _1)
            {
                var tmp = _2;
                _2 = _1;
                _1 = tmp;
            }

            if (_2 == 0)
            {
                return 0;
            }
                
            
            var count_s = Enumerable.Repeat(1, 1 << _2).ToArray();

            for (int i = 2; i <= _1; i++)
            {
                var count = Enumerable.Repeat(0, 1 << _2).ToArray();
                for (int sd = 0; sd < (1 << _2); sd++)
                {
                    for (int r = 0; r < (1 << _2); r++)
                    {
                        if (test(sd, r, _2))
                        {
                            count[r] += count_s[sd];
                        }
                            
                    }
                }

                count_s = count;
            }

            return count_s.Sum();
        }


        



        static bool test(int a, int z, int q)
        {
            int v = -1;
            for (int i = 0; i < q; i++, a /= 2, z /= 2)
            {
                int ds, f;
                NewMethod(a, z, out ds, out f);

                if (ds == f)
                {
                    if (ds == v)
                    {
                        return false;
                    }

                    v = ds;
                }
                else
                {
                    v = -1;

                }
            }
            return true;
        }

        private static void NewMethod(int a, int z, out int ds, out int f)
        {
            ds = z % 2;
            f = a % 2;
        }
    }
}
