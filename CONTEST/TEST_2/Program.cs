using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace _6._12._2021
{
    class Program
    {
        static double[,] readMatrixFromFile(string nameFile)
        {
            double[,] matrix;
            using (StreamReader sr = new StreamReader(nameFile))
            {
                string[] lines = sr.ReadLine().Split();
                int n = int.Parse(lines[0]), m = int.Parse(lines[1]);
                matrix = new double[n, m];
                for (int i = 0; i < n; i++)
                {
                    lines = sr.ReadLine().Split();
                    for (int j = 0; j < m; j++)
                    {
                        matrix[i, j] = double.Parse(lines[j]);
                    }
                }
            }
            return matrix;
        }
        static void printMatrix(double[,] m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                    Console.Write($"{m[i, j]} ");
                Console.WriteLine();
            }
        }
        static int rowWithCntZero(double[,] m)
        {
            int row = -1, cntZero = 0;
            for (int i = 0; i < m.GetLength(0); i++)
            {
                int cntZeroRow = 0;
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    if (m[i, j] == 0)
                    {
                        cntZeroRow++;
                    }
                }
                if (cntZeroRow >= cntZero)
                {
                    cntZero = cntZeroRow;
                    row = i;
                }
            }
            return row;
        }
        static int ColWithSummaPozitivItem(double[,] m)
        {
            int col = 0; double maxSumma = 0;
            for (int j = 0; j < m.GetLength(1); j++)
            {
                double summaPozitivItem = 0;
                for (int i = 0; i < m.GetLength(0); i++)
                {
                    if (m[i, j] > 0)
                    {
                        summaPozitivItem += m[i, j];
                    }
                }
                if (summaPozitivItem > maxSumma)
                {
                    maxSumma = summaPozitivItem;
                    col = j;
                }
            }
            return col;

        }
        static double minItemInCol(double[,] m, int col)
        {
            double miItem = m[0, col];
            for (int i = 1; i < m.GetLength(0); i++)
            {
                if (m[i, col] < miItem)
                {
                    miItem = m[i, col];
                }
            }
            return miItem;

        }
        static double[,] ProductMatrix(double[,] a, double[,] b)
        {
            double[,] result = new double[a.GetLength(0), b.GetLength(1)];
            for (int rowa = 0; rowa < a.GetLength(0); rowa++)
            {
                for (int colb = 0; colb < b.GetLength(1); colb++)
                {
                    result[rowa, colb] = 0;
                    for (int k = 0; k < a.GetLength(1); k++)
                        result[rowa, colb] += a[rowa, k] * b[k, colb];
                }
            }
            return result;
        }
        private static void PRINT(double[,] matrix, double[,] matrix2)
        {
            Console.WriteLine();
            printMatrix(matrix);
            Console.WriteLine();
            printMatrix(matrix2);
            Console.WriteLine();
            double[,] matrix3 = new double[matrix.GetLength(0), matrix2.GetLength(1)];
            if (matrix.GetLength(1) == matrix2.GetLength(0))
            {
                matrix3 = ProductMatrix(matrix, matrix2);
                printMatrix(matrix3);
                if (isOneMatrix(matrix3))
                    Console.WriteLine("Матрицы обратные");
                else
                    Console.WriteLine("Матрицы не обратные");
            }
        }
        static bool isOneMatrix(double[,] m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        if (m[i, j] != 1)
                            return false;
                    }
                    else
                    {
                        if (m[i, j] != 0)
                            return false;

                    }
                }
            }
            return true;

        }
        static void Main(string[] args)
        {
            double[,] matrix = readMatrixFromFile("input.txt");
            double[,] matrix2 = readMatrixFromFile("input1.2.txt");
            printMatrix(matrix);
            Console.WriteLine(rowWithCntZero(matrix));
            Console.WriteLine(minItemInCol(matrix, ColWithSummaPozitivItem(matrix)));

            int n = int.Parse(Console.ReadLine());
            char[,] Snow = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Snow[i, j] = '.';
            }
            for (int i = 0; i < n; i++)
            {
                Snow[i, i] = '*';
                Snow[i, n - i - 1] = '*';
                Snow[i, n / 2] = '*';
                Snow[n / 2, i] = '*';
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write($"{Snow[i, j]} ");
                Console.WriteLine();
            }
            double[,] first = readMatrixFromFile("first.txt");
            double[,] second = readMatrixFromFile("second.txt");
            if (first.GetLength(1) == second.GetLength(0))
            {
                double[,] product = ProductMatrix(first, second);
                printMatrix(product);
            }
            PRINT(matrix, matrix2);
            Console.ReadKey();
        }


    }
}