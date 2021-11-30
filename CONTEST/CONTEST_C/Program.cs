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
            int DAY_NUMBER = 1, COUNT_1 = 0;
            string[] MASSIVE = File.ReadAllLines("input.txt"); List<int> COURSE = new List<int>(); List<int> MINUTE = new List<int>();
            StreamWriter RT = new StreamWriter("output.txt");
            BASE(ref DAY_NUMBER, ref COUNT_1, MASSIVE, COURSE, MINUTE);
            RT.WriteLine(DAY_NUMBER);
            RT.Close();


        }

        private static void BASE(ref int DAY_NUMBER, ref int COUNT_1, string[] MASSIVE, List<int> COURSE, List<int> MINUTE)
        {
            for (int i = 1; i < MASSIVE.Length; i++)
                TEST_1(MASSIVE, COURSE, MINUTE, i);
            for (int i = 1; i < MINUTE.Count; i++)
                TEST_2(ref DAY_NUMBER, ref COUNT_1, COURSE, MINUTE, i);
        }

        private static void TEST_1(string[] MASSIVE, List<int> COURSE, List<int> MINUTE, int i)
        {
            string STRING_1 = MASSIVE[i];
            if (STRING_1[1] == '0')
                TEST_4(COURSE, STRING_1);
            else
                TEST_3(COURSE, STRING_1);
            string STRING_2 = MASSIVE[i];
            if (STRING_2[4] == '0')
                TEST_8(MINUTE, STRING_1);
            else
                TEST_7(MINUTE, STRING_2);
        }

        private static void TEST_2(ref int DAY_NUMBER, ref int COUNT_1, List<int> COURSE, List<int> MINUTE, int i)
        {
            if (MINUTE[i] - MINUTE[i - 1] <= 0 && COURSE[i] - COURSE[i - 1] > 0 || MINUTE[i] - MINUTE[i - 1] >= 0 && COURSE[i] - COURSE[i - 1] >= 0)
                COUNT_1++;
            else
                COUNT_1 = TEST_5(ref DAY_NUMBER);
            if (COUNT_1 == 10)
                COUNT_1 = TEST_6(ref DAY_NUMBER);
        }

        private static void TEST_3(List<int> COURSE, string STRING_1)
        {
            if (STRING_1[7] == 'p')
                TEST_11(COURSE, STRING_1);
            else
                TEST_9(COURSE, STRING_1);
        }

        private static void TEST_4(List<int> COURSE, string STRING_1)
        {
            if (STRING_1[7] == 'p')
                TEST_13(COURSE, STRING_1);
            else
                TEST_12(COURSE, STRING_1);
        }

        private static int TEST_5(ref int DAY_NUMBER)
        {
            int COUNT_1 = 0;
            DAY_NUMBER++;
            return COUNT_1;
        }

        private static int TEST_6(ref int DAY_NUMBER)
        {
            int COUNT_1;
            DAY_NUMBER++;
            COUNT_1 = 0;
            return COUNT_1;
        }

        private static void TEST_7(List<int> MINUTE, string STRING_2)
        {
            string F = STRING_2[4].ToString() + STRING_2[5];
            int V = Convert.ToInt32(F);
            MINUTE.Add(V);
        }

        private static void TEST_8(List<int> MINUTE, string STRING_1)
        {
            int G = Convert.ToInt32(STRING_1[5].ToString());
            MINUTE.Add(G);
        }

        private static void TEST_9(List<int> COURSE, string STRING_1)
        {
            string sum = STRING_1[1].ToString() + STRING_1[2];
            int L = Convert.ToInt32(sum.ToString());
            if (L == 12)
                COURSE.Add(0);
            else
                COURSE.Add(L);
        }

        private static void TEST_11(List<int> COURSE, string STRING_1)
        {
            string sum = STRING_1[1].ToString() + STRING_1[2];
            int K = 12 + Convert.ToInt32(sum.ToString());
            if (K == 24)
                COURSE.Add(12);
            else
                COURSE.Add(K);
        }

        private static void TEST_12(List<int> COURSE, string STRING_1)
        {
            int N = Convert.ToInt32(STRING_1[2].ToString());
            COURSE.Add(N);
        }

        private static void TEST_13(List<int> COURSE, string STRING_1)
        {
            int Y = 12 + Convert.ToInt32(STRING_1[2].ToString());
            COURSE.Add(Y);
        }

    }
}
