using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace контест21
{
    class Program
    {
        private static int binSearch_rigth(int[] a, int key)
        {
            int l = -1;
            int r = a.Length;
            while (l < r - 1)
            {
                int m = (l + r) / 2;
                if (a[m] > key)
                    r = m;
                else
                    l = m;
            }

            return l;
        }
        static List<int> input()
        {
            List<int> mas = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToList();
            return mas;
        }
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split(' ');
            double a = int.Parse(strings[0]);double b = int.Parse(strings[1]);double c = int.Parse(strings[2]);double d = int.Parse(strings[3]);double eps = 1E-14, x1;




            double S = (3 * a * c - b * b) / (3 * a * a),e = (2 * b * b * b - 9 * a * b * c + 27 * a * a * d) / (27 * a * a * a), DET = e * e / 4.0 + S * S * S / 27.0;
            if (DET > 0)
            {
                double form = -e / 2.0 + Math.Sqrt(DET);
                form = Math.Exp(Math.Log(form) / 3.0);
                double qwe = form - S / (3.0 * form);
                x1 = qwe - b / (3.0 * a);

            }
            else
            {
                if (Math.Abs(e) < eps)
                    x1 = -b / (3 * a);
                else
                {
                    double ex = Math.Exp(Math.Log(Math.Abs(e) / 2) / 3);
                    if (e < 0)
                        ex = -ex;
                    x1 = -2 * ex - b / (3 * a);

                }
            }
            Console.WriteLine("{0:0.000000}", x1);
            Console.ReadKey();
        }
    }
}