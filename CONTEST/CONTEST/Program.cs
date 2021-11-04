using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTEST_A
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int I = 0, p = 0, MAX_COUNT = 0; int N = int.Parse(Console.ReadLine()); List<long> MAS_1 = new List<long>(); List<long> MAS_2 = new List<long>();
            for (int i = 0; i < N; i++)
                MAS_1.Add(long.Parse(Console.ReadLine()));
            int M = int.Parse(Console.ReadLine());
            for (int i = 0; i < M; i++)
                MAS_2.Add(long.Parse(Console.ReadLine()));
            MAS_1.Sort(); MAS_2.Sort(); bool flag2, flag; NewMethod1(MAS_1, out flag2, out flag); p = MAS_2.Count - 1;
            flag = true;
            for (int i = 0; i < MAS_1.Count; i++)
            {
                NewMethod(ref I, p, ref MAX_COUNT, MAS_1, MAS_2, ref flag2, i);
            }
            Console.WriteLine(MAX_COUNT);
            Console.ReadKey();
        }

        private static void NewMethod1(List<long> MAS_1, out bool flag2, out bool flag)
        {
            flag2 = true;
            flag = true;
            while (flag != false)
            {
                flag = false;
                for (int i = 0; i < MAS_1.Count; i++)
                {
                    if (i != 0)
                    {

                        if (MAS_1[i] == MAS_1[i - 1])
                        {
                            flag = true;
                            MAS_1.RemoveAt(i - 1);
                        }
                    }
                }
            }
        }

        private static void NewMethod(ref int I, int p, ref int MAX_COUNT, List<long> MAS_1, List<long> MAS_2, ref bool flag2, int i)
        {
            while ((MAS_2[I] < MAS_1[i]) && (I != MAS_2.Count - 1))
                I++;
            while ((MAS_2[I] == MAS_1[i]) && (I < MAS_2.Count - 1))
            {
                MAX_COUNT++;
                I = I + 1;
            }
            for (int f = 0; f < MAS_1.Count; f++)
            {
                if ((MAS_2[p] == MAS_1[i]) && (flag2 == true))
                {
                    flag2 = false;
                    MAX_COUNT++;
                }
                else
                    break;
            }
        }
    }
}
