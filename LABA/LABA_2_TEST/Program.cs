using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA_2_TEST
{
    internal class Program
    {
        static public void MaxSubSeq(char[] s1, char[] s2)
        {
            // считаем матрицу
            var matrix = new int[s1.Length + 1, s2.Length + 1];
            for (var i = 1; i <= s1.Length; i++)
                for (var j = 1; j <= s2.Length; j++)
                    matrix[i, j] = s1[i - 1] == s2[j - 1] ?
                                 (matrix[i - 1, j - 1] + 1) :
                                 Math.Max(matrix[i - 1, j], matrix[i, j - 1]);

            // выводим матрицу в консоль
            for (var i = 0; i <= s1.Length; i++)
            {
                for (var j = 0; j <= s2.Length; j++)
                    Console.Write($"{matrix[i, j]}\t");
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            MaxSubSeq("dfghdh", "dfghdfg");
            Console.ReadKey();
        }
    }
}
