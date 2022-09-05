using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadIvent
{
    
    internal class Program
    {
        public static Random rnd = new Random();
        class Normal
        {
            public void Message(int n)
            {
                Console.WriteLine($"Погода корфортная, {n} градусов!");
            }
        }
        class Cold
        {
            public void Message(int n)
            {
                Console.WriteLine($"Ну вот, температура опустилась до {n}, скорее надевай носочки, чтобы не замерзнуть!!!");
            }
        }
        class Hot
        {
            public void Message(int n)
            {
                Console.WriteLine($"Ух, стало жарковато, аж целых {n}! Надевай купальник и быстро в речку!");
            }
        }
        class HumidityHight
        {
            public void Message(int n)
            {
                Console.WriteLine($"Сегодня большая влажность! Аж целых {n}%");
            }
        }
        class HumidityLow
        {
            public void Message(int n)
            {
                Console.WriteLine($"Сегодня низкая влажность! Всего-то {n}%");
            }
        }
        class TempRand : EventArgs
        {
            public int n;
        }
        class HumRand : EventArgs
        {
            public void Message(int n)
            {
                Console.WriteLine($"Сегодня низкая влажность! Всего-то {n}%");
            }
        }
        class EventsTest
        {
            Cold ColdMessage = new Cold();
            Hot HotMessage = new Hot();
            Normal NormalMessage = new Normal();
            HumidityHight HumidityHightMessage = new HumidityHight();
            HumidityLow HumidityLowMessage = new HumidityLow();
            public event EventHandler Temp;
            
            public void Indicators()
            {
                

                var thread = new Thread(() =>
                {
                    var Temp1 = new TempRand();
                    var Hum = new HumRand();
                    while (true)
                    {

                        test();
                        Thread.Sleep(500);
                    }
                }
                );
                thread.IsBackground = true;
                thread.Start();
            }

            private void test()
            {
                int hum = rnd.Next(0, 100);
                int temp = rnd.Next(-30, 30);
                //Temp(this, new EventArgs());
                if (temp < 0)
                {
                    ColdMessage.Message(temp);
                    //Temp(this, new EventArgs());
                }
                if (temp > 0 && temp < 21)
                {
                    NormalMessage.Message(temp);
                }
                if (temp > 20)
                {
                    HotMessage.Message(temp);
                    //Temp(this, new EventArgs());
                }
                if (hum < 50)
                {
                    HumidityLowMessage.Message(hum);
                }
                if (hum > 50)
                {
                    HumidityHightMessage.Message(hum);
                }
                Console.WriteLine();
            }

        }

        static void Main(string[] args)
        {
            
            var Events = new EventsTest();
            Events.Indicators();
            Console.ReadKey();
        }
    }
}
