using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CONTEST_C
{
    class Program
    {
        static void Main(string[] _1)
        {
            int VOLUE = 0;
            string[] S = File.ReadAllLines("input.txt");
            int N = Convert.ToInt32(S[0]);
            int[,] MAS_1 = new int[N, N];
            int COUNT_1 = 0;
            BASE(ref VOLUE, S, MAS_1, ref COUNT_1);
            PRINT(COUNT_1);
        }

        private static void PRINT(int COUNT_1)
        {
            StreamWriter RE = new StreamWriter("output.txt");
            RE.WriteLine(COUNT_1 / 2);
            RE.Close();
        }

        private static void BASE(ref int VOLUE, string[] S, int[,] MAS_1, ref int COUNT_1)
        {
            TEST_5(S, MAS_1);
            TEST_2(ref VOLUE, S, MAS_1, ref COUNT_1);
        }

        private static void TEST_5(string[] S, int[,] MAS_1)
        {
            for (int i = 0; i < MAS_1.GetLength(0); i++)
                TEST_4(S, MAS_1, i);
        }

        private static void TEST_4(string[] S, int[,] MAS_1, int i)
        {
            string STRING_1 = S[i + 1];
            string[] MASSIV_1 = STRING_1.Split(' ');
            TEST_3(MAS_1, i, MASSIV_1);
        }

        private static void TEST_3(int[,] MAS_1, int i, string[] MASSIV_1)
        {
            for (int j = 0; j < MAS_1.GetLength(1); j++)
                MAS_1[i, j] = Convert.ToInt32(MASSIV_1[j]);
        }

        private static void TEST_2(ref int VOLUE, string[] S, int[,] MAS_1, ref int COUNT_1)
        {
            string STRING_2 = S[S.Length - 1];
            string[] STRING_3 = STRING_2.Split(' ');
            for (int i = 0; i < MAS_1.GetLength(0); i++)
                VOLUE = TEST_1(MAS_1, ref COUNT_1, STRING_3, i);
        }

        private static int TEST_1(int[,] MAS_1, ref int COUNT_1, string[] STRING_3, int i)
        {
            int VOLUE = Convert.ToInt32(STRING_3[i]);
            for (int j = 0; j < MAS_1.GetLength(1); j++)
            {
                if (MAS_1[i, j] != 0 && VOLUE != Convert.ToInt32(STRING_3[j]))
                    COUNT_1++;
            }

            return VOLUE;
        }
    }
}
