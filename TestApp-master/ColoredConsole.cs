using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
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
            //здесь происходит магия
            //handle - наша конкретная текущая консоль от нашего консоль-аппа
            IntPtr handle = GetStdHandle(-11);

            //consoleMode - режим текущей работы консоли, его то нам и нужно изменить
            //для включения форматированного вывода с цветами
            //из-за специфики работы метода kernel32.GetConsoleMode() создаём локальную переменную заранее
            int consoleMode;

            //получаем текущий тип консоли
            GetConsoleMode(handle, out consoleMode);

            //делаем установку значения в нашу переменнут
            //документация: https://docs.microsoft.com/en-us/windows/console/setconsolemode
            //ENABLE_ECHO_INPUT 0x0004
            //из документации - Characters read by the ReadFile or ReadConsole function are written to the active screen buffer as they are typed into the console. This mode can be used only if the ENABLE_LINE_INPUT mode is also enabled.
            
            //благодаря |0x4 мы сохраняем предыдущие режимы и добавляем свой новый - ECHO_INPUT который под параметром 0x4 в исходниках майкрософтовской C#-консоли
            SetConsoleMode(handle, consoleMode | 0x4);
        }

        //_sout с использованием стандартного типа цвета ConsoleColor
        public static void _sout(this object _in, ConsoleColor col = ConsoleColor.White, bool newStr = true)                                                                        //Drawing r-g-b colors in 0-255 range by default, but r-g-b colors in Unity in 0-1 range so we need mult them to 255
        {
            //устанавливаем цвет консоли
            Console.ForegroundColor = col;

            //выводим наш текст и при переменной newStr == true выводим дополнительно \n для переноса строки
            Console.Write($"{_in}{(newStr ? "\n" : "")}");

            //после вывода форматированного цветного текста устанавливаем цвет консоли White, т.е. белый
            //стандартное значение консольного цвета
            Console.ForegroundColor = ConsoleColor.White;
        }

        //_sout с использованием System.Drawing.Color'а
        //это структура представления цвета в RGB формате от майкрософт
        public static void _sout(this object _in, Color col)                                                                        //Drawing r-g-b colors in 0-255 range by default, but r-g-b colors in Unity in 0-1 range so we need mult them to 255
        {
            //форматированнный вывод осуществляется добавлением перед выводимым текстом
            //\x1b[38;2;R;G;Bm и далее текст, где переменные R, G, B идут в формате от 0 до 255
            Console.WriteLine($"\x1b[38;2;{col.R};{col.G};{col.B}m{_in}");

            //после вывода форматированного цветного текста устанавливаем цвет консоли White, т.е. белый
            //стандартное значение консольного цвета
            Console.ForegroundColor = ConsoleColor.White;
        }

        //_sout для выведения массива цветов, цвет каждого символа выводимого текста будет интерполироваться
        //или же лерпаться плавненько между элементами массива цветов
        //короче говоря градиентный вывод
        public static void _sout(this object _in, Color[] colors)
        {
            //берём выводимый объект через ToString()
            string text = _in.ToString();
            //создаём StringBuilder для удобного Append'а в него каждого символа, т.е. добавления
            StringBuilder st = new StringBuilder();

            //циклом фор итерируем по количеству символов в строке
            for (int i = 0; i < text.Length; i++)
            {
                //берём текущий цвет в формате RGB
                //вызываем метод lerpinfinity от параметра массива цветов, и текущего оффсета смещения по нему
                //который определяем по формуле: номер_итерации / (количество_символов_в_тексте - 1)
                Color foreColor = lerpinfinity(colors, i / (text.Length - 1.0f));

                //добавляем текущий символ с полученным для него цветом из массива градиентов
                //в StringBuilder методом Append
                st.Append($"\x1b[38;2;{foreColor.R};{foreColor.G};{foreColor.B}m{text[i]}");
            }
            //выводит в стандартную консоль StringBuilder взяв у него ToString()
            Console.WriteLine(st.ToString());
        }

        //кеширование последнего используемого цвета
        //из-за того что иногда возвращается чёрный цвет
        //данный костыль позволяет выводить корректный цвет вместо изредка встречающихся
        //чёрных символов в тексте
        private static Color lastColor = Color.White;


        //метод возвращает цвет из массива цветов нашего градиента по оффсету переменной alpha
        private static Color lerpinfinity(Color[] colors, float alpha)
        {
            //тот самый костыль. если мы дошли до 0 в цикле метода _sout то возвращаем первый цвет массива цветов
            if (alpha == 0)
                return colors[0];
            //если же до 1 до последний
            else if (alpha == 1)
                return colors[colors.Length - 1];           //массив из 5 элементов вернёт длину 5, но вот взять последний элемент по индекусу нужно написав 4, потому и - 1. можно использовать .Last() от Linq, но наш код более универсальный
            
            //берём длину массива цветов с минус одним элементом, логика та же что и строкой выше
            var length = colors.Length - 1;

            //метод remap позволяет перевести значение из одного диапазона в другой
            //например между 0 и 10 число 2 является на 20%, таким образом из диапазона от 0 до 50 метод вернёт 10
            //мы же ремапаем текущее значение в итерировании по циклу символов текста, между 0 и 1 переводя его в диапазон 0 - длина цветов
            var source = remap(alpha, 0, 1, 0, length);

            //кешируем минимальный и максимальный оффсеты между которыми находится наш текущий символ в градиенте цветов
            var offsetMin = (int)Math.Floor(source);            //округление в меньшую сторону до плавающей точки
            var offsetMax = (int)Math.Ceiling(source);          //округление в большую сторону до плавающей точки

            //функция Lerp даёт элемент по смещению C в диапазоне от A до B включительно
            //где A это первый цвет массива, B последний и C мы находим при помощи ремаппинга от:
            //наше текущее положение в итерировании по символам, минимальный индекс из массива цветов / длину массива,
            //максимальный индекс из массива цветов / длина массива, 0, 1
            //переводим текущее положение итерирования по символам текста из метода выше в диапазон 0 - 1 с использованием разнообразных коррекций
            //чтобы избежать ошибок получения цвета
            //после чего попросту смешиваем между текущими мин и макс цветами получая градиентный цвет
            Color col = Lerp(colors[offsetMin], colors[offsetMax], remap(alpha, (float)offsetMin / length, (float)offsetMax / length, 0, 1));
            
            //см. lastColor комментарий
            lastColor = col;

            //возвращаем цвет текущего цвета
            return col;
        }

        //метод позволяющая получить средний цвет между s и t, то есть source и target по оффсету k что лежит в диапазоне от 0 до 1
        public static Color Lerp(Color s, Color t, float k)
        {
            var bk = (1 - k);
            var a = s.A * bk + t.A * k;
            var r = s.R * bk + t.R * k;
            var g = s.G * bk + t.G * k;
            var b = s.B * bk + t.B * k;

            //проверка на то что r, g, b или a у нас НеЧисло, то есть при неудачной операции смешивания по той или иной причине
            //мы вернём последний удачный смешанный цвет из переменной lastColor
            if (float.IsNaN(a) || float.IsNaN(r) || float.IsNaN(g) || float.IsNaN(b))
                return lastColor;

            //создаём RGB цвет из наших rgba параметров. консоль не поддерживает альфу, так что на неё там пофиг.
            return Color.FromArgb((int)a, (int)r, (int)g, (int)b);
        }

        //метод ремапы. переводит значение из одного диапазона в другой
        internal static float remap(float value, float start1, float stop1, float start2, float stop2) => start2 + (stop2 - start2) * ((value - start1) / (stop1 - start1));


        //метод приведения RGB цвета к 16-ричному hex-представлению цвета
        public static string RgbToHex(this Color rgbColor) => $"{rgbColor.R.ToString("X2")}{rgbColor.G.ToString("X2")}{rgbColor.B.ToString("X2")}";

        //метод приведения 16-ричного hex-цвета в привычный RGB типа System.Drawing.Color
        public static Color HexToRgb(this string hexColor) => ColorTranslator.FromHtml($"#{hexColor.Replace("#", "")}");               //just in case using Replace to support ffffff and #ffffff hex-strings for usability


        public static Color[] redPurpleGradient = new Color[] { "#FF00FF".HexToRgb(), "#00FFFF".HexToRgb() };
        public static Color[] purpleOrangeGradient = new Color[] { "#8A2387".HexToRgb(), "#E94057".HexToRgb(), "#F27121".HexToRgb() };          //few examples of cool gradients
        public static Color[] rainbowGradient = new Color[] { "#FF0000".HexToRgb(), "#FFFF00".HexToRgb(), "#00FF00".HexToRgb(),
            "#00FFFF".HexToRgb(), "#0000FF".HexToRgb(), "#FF00FF".HexToRgb() };
        internal static Color[] discordGradient1 = new Color[] { "#9B42F5".HexToRgb(), "#E3668C".HexToRgb() };
        internal static Color[] discordGradient2 = new Color[] { "#B473F5".HexToRgb(), "#E292AA".HexToRgb() };

        //метод получения цвета от статичного массива цветов и длины текста с параметрами ревёрса, скорости и ширины
        //работает на божьей вере
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
}
