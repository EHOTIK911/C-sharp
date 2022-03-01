using System;
using System.Activities;
using System.IO;
using System.Activities.Statements;
using System.Linq;
using System.Collections.Generic;

namespace Лаба1
{
    class Program
    {
        private static void Cont(List<int> Emp, string[] mas)
        {
            foreach (string s in mas)
            {
                Emp.Add(Convert.ToInt32(s));
            }
        }
        //-----------------//
        //Emp - растояние рабочим до дома
        //Car - тариф 
        static void Main(string[] args)
        {
            int cnt = 0;
            List<int> exception = new List<int>();
            Console.WriteLine("Введите расстояние до дома раждого рабочего");
            String CntEmploes = Console.ReadLine();
            List<int> Emp = new List<int>();
            string[] mas = new string[1];
            mas = CntEmploes.Split();
            Cont(Emp, mas);
            Console.WriteLine("Введите тарифный план каждого таксиста");
            String CntCar = Console.ReadLine();
            mas = CntCar.Split();

            List<int> Car = new List<int>();
            Cont(Car, mas);
            int[] a = new int[Car.Count];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = 0;
            }
            cnt = Chek(cnt, Emp, Car, a);
            ////Emp.Sort();
            ////Car.Sort();
            ////Car.Reverse();
            ////for (int i = 0; i < Car.Count; i++)
            ////{

            ////}
            //for (int i = 0; i < Car.Count; i++)
            //{
            //    Console.WriteLine($"{Emp[i]}  {Car[i]}");
            //}
            OutPut(a);
            Console.ReadKey();
        }

        private static int Chek(int cnt, List<int> Emp, List<int> Car, int[] a)
        {
            while (cnt < Car.Count)
            {
                int Max = Emp.Max();
                int MaxLock = Emp.IndexOf(Max);
                int Min = Car.Min();
                int MinLock = Car.IndexOf(Min);
                a[MinLock] = MaxLock;
                Emp[MaxLock] = -1;
                Car[MinLock] = 100000;
                cnt++;
            }

            return cnt;
        }

        private static void OutPut(int[] a)
        {
            foreach (int s in a)
            {
                Console.WriteLine(s + 1);
            }
        }
        //-----------------//

    }
}