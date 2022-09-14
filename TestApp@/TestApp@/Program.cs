using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using static System.Drawing.Color;
using static TestApp_.ColoredConsole;
using System.Runtime.InteropServices;

namespace TestApp_
{
    internal static class ColoredConsole
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetConsoleMode(IntPtr handle, out int mode);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int handle);

        internal static void Set()
        {
            var handle = GetStdHandle(-11);
            int consoleMode;
            GetConsoleMode(handle, out consoleMode);
            SetConsoleMode(handle, consoleMode | 0x4);
        }

        public static void _sout(this object _in, Color col, bool unity = false)                                                                        //Drawing r-g-b colors in 0-255 range by default, but r-g-b colors in Unity in 0-1 range so we need mult them to 255
        {
            Console.WriteLine($"\x1b[38;2;{col.R * (unity ? 255 : 1)};{col.G * (unity ? 255 : 1)};{col.B * (unity ? 255 : 1)}m{_in}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void _sout(this object _in, Color[] colors, bool unity = false)
        {
            string text = _in.ToString();
            StringBuilder st = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                var hexColor = RgbToHex(lerpinfinity(colors, i / (text.Length - 1.0f)));
                Color foreColor = HexToRgb(hexColor);
                st.Append($"\x1b[38;2;{foreColor.R * (unity ? 255 : 1)};{foreColor.G * (unity ? 255 : 1)};{foreColor.B * (unity ? 255 : 1)}m{text[i]}");
            }
            Console.WriteLine(st.ToString());
        }

        private static Color lastColor = Color.White;           //we always cache prev array color to use if we get whole black or white color in gradienting process

        private static Color lerpinfinity(Color[] colors, float alpha)
        {
            if (alpha == 0)
                return colors[0];
            else if (alpha == 1)
                return colors[colors.Length - 1];
            var length = colors.Length - 1;
            var source = remap(alpha, 0, 1, 0, length);
            var offsetMin = (int)Math.Floor(source);
            var offsetMax = (int)Math.Ceiling(source);
            Color col = Lerp(colors[offsetMin], colors[offsetMax], remap(alpha, (float)offsetMin / length, (float)offsetMax / length, 0, 1));
            lastColor = col;                                    //see lastColor comment
            return col;
        }

        public static bool IsNaN(this Color col) => float.IsNaN(col.R) || float.IsNaN(col.G) || float.IsNaN(col.B);

        public static Color Lerp(Color s, Color t, float k)
        {
            var bk = (1 - k);
            var a = s.A * bk + t.A * k;
            var r = s.R * bk + t.R * k;
            var g = s.G * bk + t.G * k;
            var b = s.B * bk + t.B * k;

            if (float.IsNaN(a) || float.IsNaN(r) || float.IsNaN(g) || float.IsNaN(b))
                return lastColor;
            return Color.FromArgb((int)a, (int)r, (int)g, (int)b);
        }

        internal static float remap(float value, float start1, float stop1, float start2, float stop2) => start2 + (stop2 - start2) * ((value - start1) / (stop1 - start1));



        public static string RgbToHex(this Color rgbColor) => $"{rgbColor.R.ToString("X2")}{rgbColor.G.ToString("X2")}{rgbColor.B.ToString("X2")}";
        public static Color HexToRgb(this string hexColor) => ColorTranslator.FromHtml($"#{hexColor.Replace("#", "")}");               //just in case using Replace to support ffffff and #ffffff hex-strings for usability

        public static Color[] hackmansGradient = new Color[] { "#FF00FF".HexToRgb(), "#00FFFF".HexToRgb() };
        public static Color[] hackmansGradient_2 = new Color[] { "#8A2387".HexToRgb(), "#E94057".HexToRgb(), "#F27121".HexToRgb() };          //few examples of cool gradients
        public static Color[] rainbowGradient = new Color[] { "#FF0000".HexToRgb(), "#FFFF00".HexToRgb(), "#00FF00".HexToRgb(),
            "#00FFFF".HexToRgb(), "#0000FF".HexToRgb(), "#FF00FF".HexToRgb() };

        public static Color[] GetAnimatedGradient(float length, Color[] colors, bool reverse = false, float speed = 1f, float width = 0.3f)
        {
            List<Color> toRet = new List<Color>();
            if (reverse)
            {
                colors = colors.Reverse().ToArray();
                for (float i = length - 1; i > -1; i--)
                {
                    var alphaByTime = remap((float)Math.Sin(speed * (DateTime.Now - Program.cachedTime).TotalSeconds + (width * i)), -1, 1, 0, 1);
                    toRet.Add(lerpinfinity(colors, alphaByTime));
                }
            }
            else
                for (int i = 0; i < length; i++)
                {
                    var alphaByTime = remap((float)Math.Sin(speed * (DateTime.Now - Program.cachedTime).TotalSeconds + (width * i)), -1, 1, 0, 1);
                    toRet.Add(lerpinfinity(colors, alphaByTime));
                }
            return toRet.ToArray();
        }

    }

    internal class Program
    {
        public static DateTime cachedTime;

        public static (int, Color)CortageData(string s)
        {
            int age = 0;
            Color colorName = default;

            switch (s)
            {
                case "Владимир":
                    age = 23;
                    colorName = Color.White;
                    break;
                case "Петруча":
                    age = 20;
                    colorName = Color.Aqua;
                    break;
                case "Алена":
                    age = 19;
                    colorName = Color.Beige;
                    break;
                case "Анжела":
                    age = 29;
                    colorName = Color.DeepPink;
                    break;
                case "Василий":
                    age = 17;
                    colorName = Color.Green;
                    break;
                default:
                    break;
            }


            return (age, colorName);
        }

        static void Main(string[] args)
        {
            int s = 0;
            List<string> names = new List<string>() { "Владимир", "Петруча","Алена", "Анжела", "Василий"};
            Dictionary<string, Dictionary<int, string>> dict = new Dictionary<string, Dictionary<int, string>>();
            
            for(int i = 0; i < names.Count; i++)
            {
                //var (age, colorName) = CortageData(names[i]);
                Dictionary<int, string> dict2 = new Dictionary<int, string>();
                var (age, colorName) = (names[i] == "Владимир") ? CortageData(names[i]) : (names[i] == "Петруча") ? CortageData(names[i]) :
                    (names[i] == "Алена") ? CortageData(names[i]) : (names[i] == "Анжела") ? CortageData(names[i]) : CortageData(names[i]);
                dict2.Add(age, colorName.ToString());  
    
                dict.Add(names[i], dict2);
                //Console.WriteLine(dict.Keys);
                //Console.WriteLine(dict.Values);


            }
            
            var sorted = dict.OrderBy(x => x.Key).ToDictionary(x => x.Key);

            foreach (var kvp in dict)
            {
                foreach(var kvp2 in kvp.Value)
                {
                    Console.WriteLine($"{kvp.Key}, {kvp2.Key} - {kvp2.Value}");
                    "test"._sout(Red);
                }
                
            }
            //Console.WriteLine(sorted);
            Console.ReadKey();

        }
    }
}
