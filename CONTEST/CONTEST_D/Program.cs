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


            string[] G = File.ReadAllLines(@"input.txt");
            int B = Convert.ToInt32(G[0]);int[,] MAS = new int[B, B];List<int> LIST = new List<int>();
            Random RAND = BASE(G, B, MAS, LIST);
            StreamWriter RE = new StreamWriter(@"output.txt");
            PRINT(MAS, LIST, RAND, RE);
        }

        private static Random BASE(string[] G, int B, int[,] MAS, List<int> LIST)
        {
            for (int i = 0; i <= B * B; i++)
                LIST.Add(i + 1);
            Random RAND = new Random();
            for (int i = 0; i < MAS.GetLength(0); i++)
                TEST_2(G, MAS, LIST, i);
            return RAND;
        }

        private static void PRINT(int[,] MAS, List<int> LIST, Random RAND, StreamWriter RE)
        {
            for (int i = 0; i < MAS.GetLength(0); i++)
                PRINT_2(MAS, LIST, RAND, i);
            RE.Close();
        }

        private static void PRINT_2(int[,] MAS, List<int> LIST, Random RAND, int i)
        {
            for (int j = 0; j < MAS.GetLength(1); j++)
                PRING_1(MAS, LIST, RAND, i, j);
            Console.WriteLine();
        }

        private static void PRING_1(int[,] MAS, List<int> LIST, Random RAND, int i, int j)
        {
            if (MAS[i, j] == 0)
                TEST_3(MAS, LIST, RAND, i, j);
            Console.Write(MAS[i, j] + " ");
        }

        private static void TEST_3(int[,] MAS, List<int> LIST, Random RAND, int i, int j)
        {
            int Y = RAND.Next(0, LIST.Count - 1);
            MAS[i, j] = LIST[Y];
            LIST.RemoveAt(Y);
        }

        private static void TEST_2(string[] G, int[,] MAS, List<int> LIST, int i)
        {
            string STRING = G[i + 1];
            string[] mas = STRING.Split(' ');
            for (int j = 0; j < MAS.GetLength(1); j++)
                TEST_1(MAS, LIST, i, mas, j);
        }

        private static void TEST_1(int[,] MAS, List<int> LIST, int i, string[] mas, int j)
        {
            MAS[i, j] = Convert.ToInt32(mas[j]);
            if (Convert.ToInt32(mas[j]) != 0)
                LIST.Remove(Convert.ToInt32(mas[j]));
        }
    }
}

