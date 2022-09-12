using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;


namespace Do_While
{
    
    
internal class Program
    {
        public static Dictionary<int, string> word = new Dictionary<int, string>()
        {
            {1,"Дом"},
            {2,"Стул"},
            {3,"Магия"},
            {4,"Стол"},
            {5,"Небо"},
            {6,"Облако"},
            {7,"Поток"},

        };

        static void Main(string[] args)
        {
            

            int i = 0;
            do
            {
                Task task = Task.Run(() => Tasks());
                Thread.Sleep(1000 + i * 500);
             // Task.Delay(i + i).Wait();

                i = i + 500;
            } while (i <= 4000);

        }
        static void Tasks()
        {
            Random rnd = new Random();
            List<int> list = new List<int>();
            int a = rnd.Next(1, 7);
            Console.WriteLine($"{a} - {word[a]}");
            //list.Add(a);
            //if (list.Contains(a))
            //{
            //    a = rnd.Next(1, 7);
            //}
            //else
            //{
            //    list.Add(a);
                
            //}
           // Console.WriteLine(word[a]);
        }
    }
}
