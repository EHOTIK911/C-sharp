using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Colored
{
    internal static class ColoredConsole
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetConsoleMode(IntPtr handle, out int mode);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int handle);

        public static Color HexToRgb(this string hexColor) => ColorTranslator.FromHtml($"#{hexColor.Replace("#", "")}");
    }
        

    internal class Program
    {
        
        static void Main(string[] args)
        {
            double alpha = 0;
            Console.WriteLine("Введите HEX");
            string s = Console.ReadLine();
            var ss = s.HexToRgb();
            Console.Clear();
            Console.WriteLine("Что мы делаем?");
            Console.WriteLine("1. Осветлить");
            Console.WriteLine("2.затемнить");
            int ans = int.Parse(Console.ReadLine());
            switch (ans)
            {
                
            }
            //int r = Convert.ToInt32(s1, 16);
            //int g = Convert.ToInt32(s2,16);
            //int b = Convert.ToInt32(s3, 16);

            Console.ReadKey();
        }
    }
}
