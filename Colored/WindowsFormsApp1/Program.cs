using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        public static Color HexToRgb(this string hexColor) => ColorTranslator.FromHtml($"#{hexColor.Replace("#", "")}");
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Console.WriteLine("Введите HEX");
            string s = Console.ReadLine();

            string s1 = "" + s[0] + s[1];
            string s2 = "" + s[2] + s[3];
            string s3 = "" + s[3] + s[4];
            int r = Convert.ToInt32(s1, 16);
            int g = Convert.ToInt32(s2, 16);
            int b = Convert.ToInt32(s3, 16);
            Console.WriteLine($"{r}.{g}.{b}");
            Console.ReadKey();


            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
