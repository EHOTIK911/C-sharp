using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TASK_2
{
    class Program
    {
        static int[][] readMatrixFromFile(string nameFile)
        {
            int[][] m;
            using (StreamReader sr = new StreamReader(nameFile))
            {
                string[] lines = sr.ReadLine().Split();
                int n = int.Parse(lines[0]);
                m = new int[n][];
                for (int i = 0; i < n; i++)
                {
                    lines = sr.ReadLine().Split();
                    m[i] = new int[lines.Length];
                    for (int j = 0; j < m[i].Length; j++)
                    {
                        m[i][j] = int.Parse(lines[j]);
                    }

                }
                return m;
            }

        }
        static int SUMMA(int[] array)
        {
            int summa = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int item = array[i];
                summa += item;
            }
            return summa;
        }
        static int[] BubbleSortOnce(int[] s)
        {
            int i, z, x = s.Length - 1, y, tmp;
            for (y = x; y >= 1; y--)
                if (s[y] < s[y - 1])
                {
                    tmp = s[y];
                    s[y] = s[y - 1];
                    s[y - 1] = tmp;
                }
            return s;
        }
        static void Main(string[] args)
        {
            List<int> Sorted = new List<int>();
            int max = 0;
            int[][] matrix = readMatrixFromFile("input.txt");
            for (int g = 0; g < matrix.Length; g++)
            {
                int[] row = matrix[g];
                for (int i = 0; i < row.Length; i++)
                {
                    int item = row[i];
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < matrix.Length; i++)
            {
                int[] row = matrix[i];
                Console.WriteLine(SUMMA(row));
                Sorted.Add(SUMMA(row));
            }
            int[] Sorted1= Sorted.ToArray();
            BubbleSortOnce(Sorted1);
            for (int d = 0; d < matrix.Length; d++)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    int[] row = matrix[i];
                    int INdex = Array.IndexOf(Sorted1,SUMMA(row));
                    int[] Row = matrix[i];
                    matrix[i] = matrix[INdex];
                    matrix[INdex] = Row;
                }
            }

            Console.WriteLine();

            for (int g = 0; g < matrix.Length; g++)
            {
                int[] row = matrix[g];
                for (int i = 0; i < row.Length; i++)
                {
                    int item = row[i];
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}

