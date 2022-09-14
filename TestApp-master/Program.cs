using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;
using Newtonsoft.Json;
using static System.ConsoleColor;
using static TestApp.ColoredConsole;

namespace TestApp
{
    interface Interface1
    {
        void Test();
    }
    interface Interface2
    {
        void Test();
    }

    class InterfaceTest : Interface1, Interface2
    {
        //при отдельном определении методов для двух интерфейсов модификатор public неприменим
        //что означает, что мы обязаны делать апкаст либо до Interface1 либо до Interface2
        //в зависимости от того, какой реализованный метод хотим использовать
        void Interface1.Test()
        {
            Console.WriteLine("переопределён метод Test() для интерфейса Interface1");
        }
        void Interface2.Test()
        {
            Console.WriteLine("переопределён метод Test() для интерфейса Interface2");
        }

        //этот же вариант вызовется без апкаста от типа InterfaceTest2, для двух методов выше необходим апкаст до интерфейса
        public void Test()
        {
            Console.WriteLine("переопределён метод Test() обоих интерфейсов в классе InterfaceTest");
        }
    }




    //Интерфейс - аспект языка, служащий для формирования совокупности всех публичных членов класса
    interface IRequest
    {
        public string host { get; set; }
        public bool Connect();
        public string Send(string msg);
    }

    //классы реализующий интерфейс обязан реализовать методы интерфейса
    public class Request : IRequest
    {
        public string host { get; set; }
        public bool Connect()
        {
            Console.WriteLine("Подключение");
            return true;
        }

        public string Send(string msg)
        {
            Console.WriteLine($"Отправляем сообщение: {msg}");
            return "Success";
        }

        public string Ping()
        {
            Console.WriteLine("Ping?");
            return "Pong!";
        }
    }

    public class Animal
    {
        public string Name { get; set; }
        public virtual void Say()
        {
            Console.WriteLine("я есть живность");
        }
    }

    public class Rabbit : Animal
    {
        public override void Say()
        {
            Console.WriteLine("вжух-вжух");
        }
    }

    public class Dog : Animal
    {
        public override void Say()
        {
            Console.WriteLine("гаф!");
        }
    }

    public class Kitty : Animal
    {
        public override void Say()
        {
            Console.WriteLine("мяу?");
        }
    }

    public class Mouse : Animal
    {
    }


    public class Food           //еда нашего котика
    {
        public string _name;
        public string name { get; set; }
    }
    public class Cat            //наш котик
    {
        public Food food;
        public string name;

        public int age;

        //пример использования лямбда-выражения вместо тела если кода всего-то одна строчка
        public int GetAge() => age;
    }
    public static class Extentions
    {
        //пример метода-расширения доступ к которому можно получить
        //написав строка.Test() и сразу же вызвать метод
        //при помощи ключевого слова this перед типом параметра
        public static void Test(this string str)
        {
            Console.WriteLine($"строка: {str}");
        }
    }

    public class Furniture
    {
        public string name;
        public int price;
    }
    public static class House
    {
        public static List<Furniture> furnitures = new List<Furniture>();
    }

    public enum Test
    {
        Message = 1,
        Warning = 2,
        Error = 3
    }

    class WeatherArgs : EventArgs
    {
        public string @string;
    }

    class WeatherEvent
    {
        public Random rnd = new Random();
        public event EventHandler OnTemperatureChanged;
        public event EventHandler OnHumanityChanged;

        public void Dispatcher()
        {
            var update = new Thread(() =>
            {
                while (true)
                {
                    var hum = rnd.Next(0, 100);
                    var temp = rnd.Next(-30, 30);

                    if (hum > 90)
                    {
                        OnTemperatureChanged(this, new WeatherArgs() { @string = "Высока вероятность дождя, влажность > 90" });
                    }
                    else if (hum > 60)
                    {
                        OnTemperatureChanged(this, new WeatherArgs() { @string = "Есть вероятность дождя, влажность > 60" });
                    }
                    else if (hum < 20)
                        OnTemperatureChanged(this, new WeatherArgs() { @string = "Есть вероятность пожаров, влажность < 20" });

                    if (temp < 0)
                    {
                        OnTemperatureChanged(this, new WeatherArgs() { @string = "Заморозки, температура < 0" });
                        if (temp < -20)
                            OnTemperatureChanged(this, new WeatherArgs() { @string = "Есть вероятность гололёда, температура < 0" });
                    }
                    else if (temp > 20)
                        OnTemperatureChanged(this, new WeatherArgs() { @string = $"Погода хорошая, {temp} градусов" });
                    Thread.Sleep(1000);
                }
            });
            update.IsBackground = true;
            update.Start();

        }
    }
    


    class TestArgs : EventArgs
    {
        public int @int = 0;
    }
    class TestEvent
    {
        public int ticksAmount { get; private set; }

        public event EventHandler Tick;
        //private int tickNum = 0;

        public TestEvent()
        {
            ticksAmount = 10;
        }

        public void Dispatcher()
        {
            for (int i = ticksAmount; i >= 0; i--)
            {
                if (ticksAmount == 0)
                {
                    if (Tick != null)
                    {
                        Tick(this, new EventArgs());
                    }
                }

                ticksAmount--;
            }
            var thread = new Thread(() =>
            {
                var args = new TestArgs();
                while (true)
                {
                    Tick(this, args);
                    args.@int++;
                    Thread.Sleep(1000);
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }
    }

    class Program
    {
        private static async Task GetMyWeather()
        {
            var res = await WeatherCheck.CheckWeather("Ulyanovsk");
            Console.WriteLine("done!");
            Console.WriteLine($"Weather in: {res.City}, sunset/sunrise: {res.Sunset.ToString("h:mm:ss tt")}/{res.Sunrise.ToString("h:mm:ss tt")}\n{res.WeatherStatus}, temperature: {res.CurrentTemp}, feels: {res.FeelsLike} (range: {res.MinTemp} - {res.MaxTemp})\nWind: {res.WindSpeed} ({res.WindDirection})");

        }

        static void Main(string[] args)
        {
            ColoredConsole.Set();
            //Task.Run(GetMyWeather);


            /*Console.ReadKey();
            Console.ReadKey();
            Console.ReadKey();
            Thread thread = new Thread(() =>
            {
                int j = 0;
                while (true)
                {
                    Console.WriteLine(j);
                    j++;
                    Thread.Sleep(100);
                }
            });
            thread.IsBackground = true;
            thread.Start();

            Test g = Test.Warning;
            Console.WriteLine($"test: {g} {(int)g}");
            g = (Test)3;

            Console.WriteLine($"test: {g} {(int)g}");
            
            //Урок 1

            Cat[] a = new Cat[10];                      //создаём массив котиков длиной 10 символов
            for (int i = 0; i < 10; i++)
            {
                a[i] = new Cat();                       //создаём инстанс котика под каждый индекс массива
                a[i].age = 95 + i;                      //устанавливаем возраст нашего котика, первые 4 элемента будут < 100, 1 с сотней, и остальные 5 выше 100
            }
            var b = a.Where(x => x.age == 100);         //выбираем из всего массива котиков котиков с конкретным возрастом
            Console.WriteLine(string.Join(", ", b));    //выводим массив котиков с возрастом выше 100 разделив запятой при помощи метода string.Join

            Dictionary<int, object> dict = new Dictionary<int, object>();       //создаём локальную переменную типа словарь с ключом типа int и значением типа object
            dict[1] = "one";                            //устанавливаем значение по ключу 1 равное строке "one"
            dict[2] = "two";                            //устанавливаем значение по ключу 2 равное строке "two"

            foreach (var item in dict)                  //циклом foreach пробегаемся по всем элементам нашего словаря
            {
                Console.WriteLine($"{item.Key} - {item.Value}");                //выводим в консоль значения словаря в формате "КЛЮЧ - ЗНАЧЕНИЕ"
            }

            var qwe = 12;           //объявляем наши переменные для тестирования
            var asd = 2;            //спойлер: выведет "two"
            var zxc = 3;            //это здесь вообще не используется, забавно вышло

            string oop = string.Empty;                  //объявляем нашу строку с результатом, можно использовать ""
            
            //пример на if-else структуре
            if (qwe == 1)
                oop = "one";
            else if (asd == 2)
                oop = "two";
            else
                oop = "not one or two";
            
            //тоже самое но короче при помощи тернарных операторов
            oop = qwe == 1 ? "one" : asd == 2 ? "two" : "not one or two";

            oop = oop ?? "";        //проверка на null и присвоение пустой строки если oop это null при помощи ?? которая здесь не нужна кстати

            Console.WriteLine(oop);             //вывод результата в консоль

            Cat cat = new Cat();       //объявление класса котика с возрастом 10 и именем Vasya
            cat.age = 10;
            cat.name = "Vasya";
            cat.food = new Food() { name = "konservi" };    //установка еды для Vasya с именем Konservi,
                                                            //написано более сокращённо чем объявление класса котика

            Console.WriteLine(cat.food?.name);              //если бы мы не дали котику еду то вывелась бы пустая строка с переносом
                                                            //без ? после поля food перед точкой - произошёл бы null reference exception
                                                            //то есть исключение нулевой ссылки на поле food

            //сериализуем нашего котика в Json, бедный котик
            var serializedCat = JsonConvert.SerializeObject(cat);
            
            //выводим сериализованного котика в консоль
            Console.WriteLine(serializedCat);               
            
            //десериализуем нашего котика из Json'а обратно в Котика
            var deserializedCat = JsonConvert.DeserializeObject<Cat>(serializedCat);    

            //чтобы убедиться в работоспособности - проверяем поля нашего котика
            Console.WriteLine($"cat name: {cat.name}, cat age: {cat.age}, cat food-name: {cat.food.name}");



            //Урок 2

            Task.Run(CheckMyIp);            //запускаем асинхронную (модификатор доступа метода async) задачу (тип Task)
            */


            //Урок 3

            //вызов метода без параметров, col будет ConsoleColor.White
            /*"Тест написанный белым"._sout();

            //вызов метода с параметром переопределяющим стандартное значение параметра col, col будет ConsoleColor.White                  
            "Тест написанный красным"._sout(ConsoleColor.Red);

            //берём элементы enum'а ConsoleColor и берём параметр длины
            var consoleColorsCount = Enum.GetNames(typeof(ConsoleColor)).Length;
            for (int i = 0; i < consoleColorsCount; i++)        //циклом фор по количеству цветом итерируем
            {
                //приводим int к типу енама
                var col = (ConsoleColor)i;

                //выводим название и передаём наш цвет параметром в каждом из циклов
                $"Тест написанный цветом: {col}"._sout(col);
            }

            //устанавливаем параметр времени 'запуска' программы, он пригодится далее
            cachedTime = DateTime.Now;

            //инициализируем нашу консоль с расширенными цветами
            //вывод будет происходить во всю ту же консоль, только с собственным форматированием цветов
            //в формате rgb
            ColoredConsole.Set();

            //тестируем вызывая метод _sout от оранжевого цвета с кастомных форматированием
            "Оранжевый текст :/"._sout(Color.Orange);

            //тестируем вызывая метод _sout от различных градиентов с кастомных форматированием
            "Красно-фиолетовый градиент"._sout(ColoredConsole.redPurpleGradient);
            "Фиолетово-оранжевый градиент"._sout(ColoredConsole.purpleOrangeGradient);
            "И ещё один красивый градиентик"._sout(ColoredConsole.discordGradient1);
            "А ещё прикольный градиентик"._sout(ColoredConsole.discordGradient2);
            "Ну а это вот радужный градиентик"._sout(ColoredConsole.rainbowGradient);

            for (int i = 0; i < 15; i++)
            {
                var num = rnd.Next(0, ColoredConsole.rainbowGradient.Length - 1);
                $"{i}"._sout(ColoredConsole.rainbowGradient[num]);
            }


            //вывод пустой строки для разделения информации
            Console.WriteLine();

            //локальный, а не глобальный, метод ReadText с параметром string p
            void ReadText(string p)
            {
                //считывание текстового файла по пути p
                var text = File.ReadAllText(p);

                //првоерка: если файл не содержит \n т.е. переноса строк
                if (!text.Contains("\n"))
                {
                    //вывод считанного пути и текста файла в консоль
                    Console.WriteLine($"Текстовый файл по пути {p} содержит: {text}");
                }
                //иначе построчное считывание
                else
                {
                    //построчное считывание методом ReadAllLines()
                    //если бы в файле была одна строка - считал бы одну строку, логично же?
                    string[] textArray = File.ReadAllLines(p);

                    //вывод в консоль количества строк и пути
                    Console.WriteLine($"Текстовый файл по пути {p} содержит {textArray.Length} строк:");

                    //цикл фор итерирующий по количеству строк
                    for (int i = 0; i < textArray.Length; i++)
                    {
                        //берём строку по индексу
                        text = textArray[i];

                        //выводим номер строки и строку
                        Console.WriteLine($"{i}) {text}");
                    }
                }
            }

            //локальная переменная пути к нашему текстовому файлу, полный путь указывается в формате "@C:/Users/..."
            string path = "text.txt";

            //проверка: существует ли файл по указанному пути
            if (File.Exists(path))
            {
                //если да - вызов локального метода с чтением файла по пути
                ReadText(path);
            }
            //иначе - запись в файл
            else        
            {
                //запись строки "Какой-то текст" в текстовый файл по указанному пути. файл может быть и не текстовым, можно хоть байты картинки записать в файл типа .png к примеру
                File.WriteAllText(path, "Какой-то текст");

                //вызов локального метода с чтением файла по пути
                ReadText(path);
            }

            //вывод пустой строки для разделения информации
            Console.WriteLine();

            //удаление файла по указанному пути
            File.Delete(path);

            //создание массива строк
            var data = new string[] { "Какой-то", "текст", "в несколько строк" };

            //запись массива строк построчно в текстовый файл, одна строка из массива на одну строку в файле
            File.WriteAllLines(path, data);

            //чтение файла
            ReadText(path);

            //удаление файла по указанному пути
            File.Delete(path);*/



            //Урок 4

            /*var animals = new List<Animal>();

            //создаём зверинец из переменных, типы которых наследуются от класса Animal
            Rabbit rabbit = new Rabbit();
            rabbit.Name = "Vasiliy";

            Kitty kitty = new Kitty();
            kitty.Name = "Pushistik";

            Dog dog = new Dog();
            dog.Name = "Tuzik";

            //апкастом добавляем всех животных в лист типа родительского класса Animal
            animals.Add(rabbit);
            animals.Add(kitty);
            animals.Add(dog);

            //форичем пробегаемся по всем живностям
            foreach (Animal item in animals)
            {
                //имена будут в том порядке в котором мы добавляли живностей
                //а именно: Vasiliy, Pushistik, Tuzik
                Console.WriteLine($"Живность {item.Name} говорит:");
                item.Say();
                Console.WriteLine();
            }

            //это апкаст
            Animal animal = new Kitty();

            Console.WriteLine("котик говорит:");

            //выведется "мяу?", а не "я есть живность", потому что мы переопределили метод Say()
            //это возможно благодаря спецификатору virtual в родительском классе Animal
            //и спецификатору override в наследнике классе Kitty метода Say()
            animal.Say();

            //создаём непонятную зверушку
            Animal animal2 = new Animal();

            Console.WriteLine("непонятная зверушка говорит:");

            //выведется "я есть живность", потому что мы вызываем метод Say()
            //в родительском классе
            //и вызывается именно его переопределение метода Say()
            animal2.Say();

            //создаём непонятную зверушку
            Mouse mouse = new Mouse();

            Console.WriteLine("Мышь говорит:");

            //выведется "я есть живность", потому что в наследнике Mouse
            //не переопределён метод Say()
            mouse.Say();

            Console.WriteLine();

            //создаём переменную того же типа что и присваиваемое значение
            Request request2 = new Request();
            request2.host = "host";
            request2.Connect();
            request2.Send("message");
            //метод Ping() реализованный в классе Request доступен
            Console.WriteLine(request2.Ping());

            //апкаст, из-за которого мы не можем получить доступ к методам и свойства не находящимся в классе родителей
            //даже не смотря на то, что в наследнике они есть
            IRequest request = new Request();
            request.host = "host";
            request.Connect();
            request.Send("message");

            //Console.WriteLine(request.Ping());        //инкапсуляция путём апкаста

            //метод Ping() реализованный в классе Request недоступен для вызова из переменной request
            //полученной путём апкаста наследника к родителю к типу интерфейса IRequest


            //создаём InterfaceTest без апкаста
            InterfaceTest interfaceTest = new InterfaceTest();

            //выведет "переопределён метод Test() обоих интерфейсов в классе InterfaceTest"
            interfaceTest.Test();

            //апкастим InterfaceTest до Interface1
            Interface1 interface1 = interfaceTest;

            //выведет "переопределён метод Test() для интерфейса Interface1"
            interface1.Test();

            //апкастим InterfaceTest до Interface1
            Interface2 interface2 = interfaceTest;

            //выведет "переопределён метод Test() для интерфейса Interface2"
            interface2.Test();*/



            //Урок 5

            //условный счётчик по которому будем менять переменную и проверять в цикле ли мы
            /*int state = 2;

            //создаём nullable переменную типа bool
            Nullable<bool> nullableBoolean;

            //цикл while (условие), пока наш state < 3 код будет выполняться в нём
            //0 будет использоваться для присвоении нуллабл-переменной значение false
            //1 для true
            //2 для обнуления значения, присвоения null
            while (state < 3)
            {
                //проверка и установка значения через тернерный оператор
                nullableBoolean = state == 2 ? null : state == 1 ? true : false;

                //блоки if-else'а для проверки значений и вывода в консоль
                if (nullableBoolean == null)
                    "Переменная nullableBoolean имеет значение null"._sout(Cyan);
                else if (nullableBoolean.Value)
                    "Переменная nullableBoolean имеет значение True"._sout(Green);
                else if (!nullableBoolean.Value)
                    "Переменная nullableBoolean имеет значение False"._sout(Red);

                //спрашиваем в консоли что нужно сделать
                "Введите значение nullableBoolean переменной (0 - false, 1 - true, 2 - null, 3 - выйти из цикла: "._sout(Yellow, false);

                //считываем введённое в консоль значение
                var input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    //присваиваем введённое в консоль значение переменной
                    state = int.Parse(input);
                }
                //иначе просто выходим из цикла
                else
                    state = 3;
            }

            //инициализируем локальную переменную типа string и присваиваем ей значение
            string intParseStr = "asd";

            //блок try-catch
            try
            {
                //при попытке запарсить строку содержащую букву, вместо цифры, произойдёт исключение
                var num = int.Parse(intParseStr);
            }
            catch (Exception e)
            {
                //залогируем его в консоль
                $"Исключение:\n{e.Message}"._sout(Red);
            }

            //блок try-catch
            try
            {
                //метод TryParse, принимающий первым аргументом строку, а вторым ссылку на память объекта в который метод
                //при успешном парсинге запишет значение и зааутит его в премененную указанную вторым параметром out
                if (int.TryParse(intParseStr, out var num))
                {
                    $"Парсинг строки {intParseStr} равен {num}"._sout(Green);
                }
                //возвращаемый тип у метода TryParse - bool, при неуспешном парсе произойдёт не ошибка,
                //а просто вернётся false
                //это мы и заллогируем в консоль
                else
                {
                    $"Неудалось пропарсить строку {intParseStr}"._sout(Red);
                }

                //присвоим нашей переменной значение числа в строке
                intParseStr = "15";

                //уже здесь парсинг пройдёт успешно и TryParse вренёт true, а мы выведем полученный num2 в консоль
                if (int.TryParse(intParseStr, out var num2))
                {
                    $"Парсинг строки \"{intParseStr}\" равен {num2}"._sout(Green);
                }
                else
                {
                    $"Неудалось пропарсить строку {intParseStr}"._sout(Red);
                }
            }
            //как видно из примера использования TryParse'а по сравнению с простым Parse'ом исключения здесь не будет никогда
            //но мы всё же обернули его в try-catch блок для примера
            catch (Exception e)
            {
                $"Исключение:\n{e.Message}"._sout(Red);
            }

            //небольшой отступ между темами
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            //рефлекшены, отражения, reflection

            //создаём лист котиков, он у нас глобальный
            kotiki = new List<Cat>();
            for (int i = 0; i < 20; i++)
            {
                //забиваем лист рандомными котиками Васями_ 0-19 индексами на конце, возрастом номера цикла и рандомом получаем название для корма
                kotiki.Add(new Cat() { name = $"Vasya_{i}", age = i, food = new Food() { name = $"{(rnd.Next(2) == 0 ? "kitecat" : "whiskas")}" } });
                
                //выводим добавленного котика в консоль с его данными
                $"котик {kotiki[i].name}, возраст {kotiki[i].age}, название еды: {kotiki[i].food.name}"._sout();
            }

            //получаем массив всех полей в классе Program и форичаем по нему
            foreach (FieldInfo field in typeof(Program).GetFields())
            {
                //выводим значение поля
                $"Найдено поле {field.Name}"._sout(DarkCyan);

                //если название поля kotiki
                if (field.Name == "kotiki")
                {
                    //то берём значение поля через GetValue методу вызываемому от FieldInfo
                    //аргументом экземпляра (инстанса) передаём null т.к. класс Program у нас статичен и не имеет экземпляров
                    //кастуем полученное значение к типу нашего поля которое нам известно List<Cat>
                    var listKotikov = (List<Cat>)field.GetValue(null);

                    //с помощью Linq делаем выборку в листе по полю name и объединяем полученный IEnumerable с помощью string.Join разделяя элементы запятой 
                    var elements = string.Join(", ", listKotikov.Select(x => x.name));
                    
                    //выводим название поля и список всех элементов через запятую, получим список имён котиков
                    $"Элементы листа в поле {field.Name}: {elements}"._sout(DarkYellow);
                }
            }

            //укороченный вариант кода выше, в одну строку получаем и выводим значение всех имён котиков
            $"Элементы листа в поле котиков: {string.Join(", ", ((List<Cat>)(typeof(Program).GetFields().First(x => x.Name == "kotiki").GetValue(null))).Select(x => x.name))}"._sout(DarkYellow);

            //запишем в глобальную переменную количество котиков
            numberOfCats = kotiki.Count;

            //зарефлектим её значение
            //в классе Program получим все поля с флагами НеПубличный и Статичный, актуально когда полей много, такая выборка позволяет сократить
            //область работы
            //возьмём первое поле с типом int
            var reflectedNumberOfCats = typeof(Program).GetFields(BindingFlags.NonPublic | BindingFlags.Static).First(x => x.FieldType == typeof(int));

            //выведем имя поля
            $"reflectedNumberOfCats.Name: {reflectedNumberOfCats.Name}"._sout(Yellow);

            //при помощи GetValue от null потому что класс Program статичен получим значение и кастанём его к int'у
            var reflectedNumberOfCatsValue = (int)reflectedNumberOfCats.GetValue(null);

            //выведем значение поля
            $"reflectedNumberOfCatsValue: {reflectedNumberOfCatsValue}"._sout();

            //возьмём класс Food и получим все его свойства
            PropertyInfo[] foodProps = typeof(Food).GetProperties();

            //форичнемся по зарефлешеному листу котиков итерируя по каждому котику
            foreach (Cat kotik in (List<Cat>)(typeof(Program).GetFields().First(x => x.Name == "kotiki").GetValue(null)))
            {
                //запишем в локальную переменную еду котика, она будет нашим инстансом т.е. экземпляром по которому мы будем получать и устанавливать значения в это поле
                Food kotikFood = kotik.food;

                //теперь форичнемся по всем свойствам класса Food (спойлер - оно одно, это свойство name)
                foreach (PropertyInfo foodField in foodProps)
                {
                    //возьмём указатель на Get часть этого параметра, значение true позволяет брать даже не публичные поля
                    MethodInfo foodGetValue = foodField.GetGetMethod(true);

                    //возьмём указатель на Set часть этого параметра, значение true позволяет брать даже не публичные поля
                    MethodInfo foodSetValue = foodField.GetSetMethod(true);

                    //при помощи Invoke от MethodInfo гет-метода свойства еды, первым параметром экземлпяра нашего класса Food в конкретном котике и пустым массивом параметров получим значение метода
                    //массив параметров используется при рефлекте методов где массив параметров метода Invoke - список параметров самого метода который мы хотим вызвать
                    //и получить результат его выполнения в зависимости от переданных параметров
                    var foodName = foodGetValue.Invoke(kotikFood, Array.Empty<object>());

                    //выведем имя котика, поля класса еды (спойлер - оно одно, это свойство name) и его значение
                    $"{kotik.name} имеет поле еды {foodField.Name} со значением {foodName}"._sout(discordGradient1);

                    //при помощи Invoke от MethodInfo сет-метогда и массивом с одним параметром установим новое название для поля
                    //массив объектов второго параметра Invoke имеент тип object не с проста. это позволяет работать с любыми параметрами любого метода
                    //ибо object это любой тип, а следовательно и параметры можно устанавливать совершенно любые для конкретного метода
                    //естественно при попытке установить значение неверного типа произойдёт исключение (exception)
                    foodSetValue.Invoke(kotikFood, new object[] { "vkusnyashka" });

                    //вновь выведем имя котика, поля класса еды (спойлер - оно одно, это свойство name) и его значение
                    //в этом случае значение у конкретного свойства названия конкретного поля еды конкретного экземпляра котика будет иметь конкретно значение
                    //благодаря циклу мы все значения названия еды каждого котика поменяем на "vkusnyashka"
                    $"{kotik.name} имеет поле еды {foodField.Name} со значением {foodGetValue.Invoke(kotik.food, Array.Empty<object>())}"._sout(discordGradient1);
                }
            }

            Type a = typeof(Program);
            MethodInfo[] b = a.GetMethods(BindingFlags.Public | BindingFlags.Static);
            MethodInfo c = null;
            foreach (MethodInfo method in b)
            {
                ParameterInfo[] @params = method.GetParameters();

                if (@params[0].ParameterType == typeof(string) &&
                    @params[1].ParameterType == typeof(int) &&
                    @params[2].ParameterType == typeof(bool) && @params.Count() == 3)
                {
                    c = method;
                    break;
                }
            }

            if (c != null)
            {
                Type d = c.ReturnType;
                Type e = typeof(bool);
                $"test 1: {(bool)c.Invoke(null, new object[] { "test 1", 2, false })}"._sout();
                $"test 1: {(bool)c.Invoke(null, new object[] { "test 2", 4, true })}"._sout();
                $"test 1: {(bool)c.Invoke(null, new object[] { "test 3", 1, true })}"._sout();
            }*/



            //Lesson 6

            /*StaticClass1.name = "StaticClassName";

            $"Результат 10 - 5: {StaticClass1.Calculate(10, 5, StaticClass1.CalculationType.Minus)}"._sout();

            NonStaticClass1 nsc1 = new NonStaticClass1("Minus", StaticClass1.CalculationType.Minus);

            $"Результат 10 - 5: {nsc1.Calculate(10, 5)}"._sout();

            nsc1.class2 = new NonStaticClass2(new string[] { "nonstaticclass1", "minus" });

            $"класс2 аргументы: {string.Join(", ", nsc1.class2.data)}"._sout(Green);

            List<NonStaticClass1> nonstaticClasses = new List<NonStaticClass1>();
            for (int i = 0; i < Enum.GetNames(typeof(StaticClass1.CalculationType)).Count(); i++)
            {
                var currentEnum = (StaticClass1.CalculationType)i;
                var class1 = new NonStaticClass1($"Class1_{currentEnum}", currentEnum);
                class1.class2 = new NonStaticClass2(new string[] { $"nonstaticclass_{i}", currentEnum.ToString() });
                nonstaticClasses.Add(class1);
            }

            while(true)
            {
                $"Сложить (1), вычесть (2), умножить (3), разделить (4): "._sout(Cyan, false);
                var type = int.Parse(Console.ReadLine());
                $"Введите a: "._sout(Cyan, false);
                var a = float.Parse(Console.ReadLine());
                $"Введите b: "._sout(Cyan, false);
                var b = float.Parse(Console.ReadLine());

                switch (type)
                {
                    case 1:
                        var result1 = nonstaticClasses.First(x => x.currentType == StaticClass1.CalculationType.Plus).Calculate(a, b);
                        $"Результат {(StaticClass1.CalculationType)type}: {result1}"._sout(Green);
                        break;
                    case 2:
                        var result2 = nonstaticClasses.First(x => x.currentType == StaticClass1.CalculationType.Minus).Calculate(a, b);
                        $"Результат {(StaticClass1.CalculationType)type}: {result2}"._sout(Green);
                        break;
                    case 3:
                        var result3 = nonstaticClasses.First(x => x.currentType == StaticClass1.CalculationType.Multiply).Calculate(a, b);
                        $"Результат {(StaticClass1.CalculationType)type}: {result3}"._sout(Green);
                        break;
                    case 4:
                        var result4 = nonstaticClasses.First(x => x.currentType == StaticClass1.CalculationType.Divide).Calculate(a, b);
                        $"Результат {(StaticClass1.CalculationType)type}: {result4}"._sout(Green);
                        break;
                    default:
                        break;
                }
            }


            List<string> district1Names = new List<string>() { "Район-1", "Район-2", "Район-3" };
            List<string> district2Names = new List<string>() { "Район-A", "Район-B" };
            List<District[]> districts = new List<District[]>();
            District[] districtsArray = new District[3];
            District[] districtsArray2 = new District[2];
            for (int i = 0; i < districtsArray.Length; i++)
            {
                districtsArray[i] = new District();
                foreach (FieldInfo field in typeof(District).GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    if (field.Name == "name")
                    {
                        field.SetValue(districtsArray[i], district1Names[i]);
                    }
                    else if (field.Name == "number")
                        field.SetValue(districtsArray[i], i);
                }
            }
            for (int i = 0; i < districtsArray2.Length; i++)
            {
                districtsArray2[i] = new District();
                foreach (FieldInfo field in typeof(District).GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    if (field.Name == "name")
                    {
                        field.SetValue(districtsArray2[i], district2Names[i]);
                    }
                    else if (field.Name == "number")
                        field.SetValue(districtsArray2[i], i + 10);
                }
            }
            districts.Add(districtsArray);
            districts.Add(districtsArray2);

            //$"districtArray names: {string.Join(", ", districtsArray.Select(x => x.name))}, numbers: {string.Join(", ", districtsArray.Select(x => x.number))}"._sout(Green);
            //$"districtArray2 names: {string.Join(", ", districtsArray2.Select(x => x.name))}, numbers: {string.Join(", ", districtsArray2.Select(x => x.number))}"._sout(Cyan);

            List<List<string>> languages = new List<List<string>>();
            languages.Add(new List<string> { "eng", "rus" });
            languages.Add(new List<string> { "eng" });

            List<string> cityNames = new List<string>() { "Альфа", "Омега" };
            City[] citiesArray = new City[2];
            FieldInfo[] cityFields = typeof(City).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo populationField = cityFields.First(x => x.Name == "population");
            FieldInfo _languagesField = cityFields.First(x => x.Name == "_languages");

            PropertyInfo districtsProp = typeof(City).GetProperties(BindingFlags.NonPublic | BindingFlags.Instance).
                First(x => x.Name == "districts");
            MethodInfo setDistrictProp = districtsProp.GetSetMethod(true);
            MethodInfo getDistrictProp = districtsProp.GetSetMethod(true);

            for (int i = 0; i < citiesArray.Length; i++)
            {
                citiesArray[i] = new City(cityNames[i]);
                populationField.SetValue(citiesArray[i], rnd.Next(200000, 500000));
                _languagesField.SetValue(citiesArray[i], languages[i]);
                setDistrictProp.Invoke(citiesArray[i], new object[] { districts[i] });
            }

            List<Color> nationalFlagColor = new List<Color>() { Color.Green, Color.Blue };
            FieldInfo nationalFlagColorsField = typeof(National).GetFields(BindingFlags.NonPublic | BindingFlags.Instance).
                First(x => x.Name == "_nationalFlagColors");
            FieldInfo national_NameField = typeof(National).GetFields(BindingFlags.NonPublic | BindingFlags.Instance).
                First(x => x.Name == "_name");

            List<string> nationalNames = new List<string>() { "Начиональность-А", "Национальность-Б" };
            National[] nationalsArray = new National[2];

            for (int i = 0; i < nationalsArray.Length; i++)
            {
                nationalsArray[i] = new National(nationalNames[i], nationalFlagColor[i]);
                nationalFlagColorsField.SetValue(nationalsArray[i], nationalFlagColor[i]);
            }


            FieldInfo cities = typeof(Country).GetFields(BindingFlags.NonPublic | BindingFlags.Static).First(x => x.Name == "cities");
            FieldInfo nationals = typeof(Country).GetFields(BindingFlags.NonPublic | BindingFlags.Static).First(x => x.Name == "nationals");
            cities.SetValue(null, citiesArray);
            nationals.SetValue(null, nationalsArray);

            City[] citiess = ((City[])cities.GetValue(null));
            var pop = 0;
            citiess.Select(x => (int)populationField.GetValue(x)).ToList().ForEach(x => pop += x);

            typeof(Country).GetFields(BindingFlags.NonPublic | BindingFlags.Static).
                First(x => x.Name == "_population").SetValue(null, pop);

            int counter = 0;
            foreach (City city in (City[])cities.GetValue(null))
            {
                var population = (int)populationField.GetValue(city);
                $"Город {city.name} имеет население {population} и распространённые языки: {string.Join(", ", (List<string>)_languagesField.GetValue(city))}. Список районов:"._sout(Yellow);
                foreach (District district in (District[])districtsProp.GetValue(city))
                {
                    $"{counter}) Район {district.name} имеет номер {district.number}"._sout();
                    counter++;
                }

                counter = 0;
            }

            $"В стране {Country.name} распространены следующие национальности:"._sout(Magenta);
            foreach (National national in (National[])nationals.GetValue(null))
            {
                $"{counter}) {(string)national_NameField.GetValue(national)}"._sout((Color)nationalFlagColorsField.GetValue(national));
                counter++;
            }*/



            //Lesson 7

            //делегаты

            //создаём экземпляр (инстанс - instance) делегата
            //в объекте new TestDelegate находится ссылка на метод TestMethod
            /*var method = new TestDelegate(TestMethod);          //экземпляр делегата

            //здесь же более упрощённый вариант, и необходимо указание типа переменной, а не просто var
            TestDelegate method2 = TestMethod;                  //тоже экземпляр делегата

            //вызов метода через экземпляр делегата
            var result1 = method("Тестовый вызов делегата", Color.Red);
            $"result1: {result1}"._sout(Color.Yellow);
            var result2 = method2("Тестовый вызов делегата 2", Color.Green);
            $"result2: {result2}"._sout(Color.Yellow);

            GarbageMethod(method);

            //ещё один экземпляр делегата, уже с другим методов имеющим те же параметры что и сам делегат
            var method3 = new TestDelegate(TestMethod2);          //экземпляр делегата

            //объединение делегатов
            var dualDelegates = method + method3;
            //вызов делегата с двумя методами
            dualDelegates("Тестовый вызов делегата 4", Color.Cyan);

            //вывод списка методов используемых в делегате
            $"Список вызывов делегата: {string.Join(", ", dualDelegates.GetInvocationList().Select(x => x.Method.Name).ToArray())}"._sout(Color.Orange);
            
            //вычитание из нашего делегата одного из вызываемых метода
            dualDelegates = dualDelegates - method;
            //вызов делегата с одним методов после вычитания
            dualDelegates("Тестовый вызов делегата 5", Color.Pink);

            //события

            //создаём экземпляр события
            var testEvent = new TestEvent();
            //подписываемся на событие
            testEvent.Tick += OnTicksEnded;

            //вызываем обработчик события
            testEvent.Dispatcher();*/



            //Lesson 8

            //tcp клиент-сервер
            //указываем порт и локальный ip-адрес
            /*int port = 8888;
            string localAddr = "127.0.0.1";

            //переменная по которой мы будем определять что сервер запущен и можно подключать клиента к нему
            bool serverStarted = false;

            //объявление отдельного потока клиента
            //т.к. клиент ничего не будет отправлять в ответ клиента можно оставить в потоке
            //лишь для чтения полученных от сервера данных
            Thread clientThread = new Thread(() =>
            {
                //ждём пока запуститься сервер
                while (!serverStarted)
                    Thread.Sleep(100);
                while (true)
                {
                    //инициализируем tcp-клиент
                    TcpClient client = new TcpClient();
                    //подключаемся к серверу
                    client.Connect(localAddr, port);

                    //создаём массив байт в которые будет записываться полученная от сервера информация
                    byte[] dataToRead = new byte[256];
                    //инициализируем StringBuilder для записи в него ответа
                    StringBuilder response = new StringBuilder();
                    //инициализируем NetworkStream для получение потока клиента куда будет записываться приходящая от сервера информация
                    NetworkStream stream = client.GetStream();
                    //пока клиент подключен...
                    while (client.Connected)
                    {
                        do
                        {
                            //считываем количество оставшихся для чтения байт 
                            int bytesCount = stream.Read(dataToRead, 0, dataToRead.Length);
                            //получаем строку из массива байт по индексу оставшегося количества байт 
                            //и добавляем её в StringBuilder где хранится дата отправленная сервером
                            response.Append(Encoding.UTF8.GetString(dataToRead, 0, bytesCount));
                        }
                        while (stream.DataAvailable);   //пока в потоке есть данные мы их читаем

                        //выводим в консоль
                        $"Клиент получил от сервера текст: {response}"._sout(Blue);
                        //очищаем StringBuilder
                        response.Clear();
                    }
                    Console.WriteLine("Отключение от сервера");
                }
            });
            clientThread.IsBackground = true;
            clientThread.Start();

            //инициализируем TcpListener
            TcpListener server = new TcpListener(IPAddress.Parse(localAddr), port);
            //запускаем 'слушание' клиента
            server.Start();

            var lastMessage = "stop";
            while (lastMessage != "stop")
            {
                "Ожидание подключений..."._sout(Red);
                //сервер запущен, можно подключать клиента
                serverStarted = true;
                //принимаем клиента
                TcpClient client = server.AcceptTcpClient();
                "Клиент подключился"._sout(DarkYellow);

                //пока клиент подключен мы можем отправлять ему данные
                while (client.Connected && lastMessage != "stop")
                {
                    $"Введите текст для отправки клиенту: "._sout(Yellow, false);
                    //конвертируем введённый в консоль текст в массив байт
                    lastMessage = Console.ReadLine();
                    byte[] dataToSend = Encoding.UTF8.GetBytes(lastMessage);
                    //берём поток клиента, записываем в него данные для отправки с 0 отступом и размером равным длине массива байт
                    client.GetStream().Write(dataToSend, 0, dataToSend.Length);
                    //ожидаем 250мс прежде чем отправлять следующее сообщение чтобы клиент успел его принять и прочесть
                    Thread.Sleep(250);
                }
                "Клиент отключился"._sout(Red);
            }*/

            /*$"Введите url: "._sout(Green, false);
            var url = Console.ReadLine();
            Process.Start($"https://{url.Replace("https://", "")}");
            var proc = new Process();
            var steamPath = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Valve\\Steam", "InstallPath", null).ToString();
            proc.StartInfo.Arguments = "-applaunch 438100";
            proc.StartInfo.WorkingDirectory = "F://Program Files//steamapps//common//VRChat";
            proc.StartInfo.FileName = $"{steamPath}\\steam.exe";
            proc.Start();

            var currentProcess = Process.GetProcesses();
            $"currentProcess:\n{string.Join("\n", currentProcess.Select(x => x.ProcessName))}"._sout();

            Console.ReadKey();
            Process.GetProcesses().ToList().ForEach(x =>
            {
                $"{x.ProcessName} runtime: {x.StartTime.ToString("h:mm:ss tt")}"._sout();
            });

            var data = new Dictionary<int, string>();
            for (int i = 1; i < 501; i++)
            {
                $"{i} - {ToRoman(i)}"._sout();
                data[i] = ToRoman(i);
            }

            List<KeyValuePair<int, string>> data2 = data.OrderBy(new Func<KeyValuePair<int, string>, object>(x => x.Value.Length)).ToList();
            data2.Reverse();
            $"{data2[0].Key} - {data2[0].Value}"._sout(Red);

            var regeditFolder = @"Software\111TestApp";

            Registry.CurrentUser.DeleteSubKey(regeditFolder);*/


            /*var weather = new WeatherEvent();
            weather.OnHumanityChanged += OnHumanityChanged;
            weather.OnTemperatureChanged += OnTemperatureChanged;
            weather.Dispatcher();
            Console.ReadKey();*/



            //Lesson 9

            //объявляем массив чисел с которыми будет работать метод GetData
            var ints = new int[] { 10, 5 };

            //вызываем метод GetData, он складывает и перемножает числа из массива и возвращает результат
            //в виде кортежа
            //здесь представлен первый вариант отображения переменнтой кортежа,
            //мы объявляем 2 локальных переменных чтобы было проще работать с кортежем
            var (sum, mult) = GetData(ints);

            //выводим в консоль
            $"sum: {sum}, mult: {mult}"._sout(Color.White);

            //здесь же кортеж GetColor возвращает цвет созданный из RGB и его ToString() представление
            //запишем его просто в локальную переменную
            var colorData = GetColor(255, 0, 128);

            //в таком виде с кортежем работать не так удобно
            //ибо значения хранятся в его полях Item1 и Item2 того же типа
            //что и в самом кортеже
            $"colorName: {colorData.Item2}"._sout(colorData.Item1);

            //здесь же кортеж из трёх переменных
            //третьей переменной мы добавили рандомное число
            //условный Id нашей операции по получению цвета
            var (colorName, color, colorId) = GetColor2(0, 128, 255);

            //выведем в консоль
            $"colorName: {colorName}, id: {colorId}"._sout(color);
            Console.WriteLine();


            //объявим словарь и заполним его парами ключ-строка и значение-число
            var dict = new Dictionary<string, int> { { "a", 1 }, { "b", 2 }, { "c", 3 }, { "d", 4 } };

            //с помощью linq выберем из словаря ключ-значение и сохраним в переменную
            var keysAndValues = dict.Select(x => $"{x.Key} - {x.Value}");

            //с помощью string.Join приведём их к строке объединив строки пар ключ-значение и разделим запятой
            var keysAndValuesStr = string.Join(", ", keysAndValues);
            $"keys and values: {keysAndValuesStr}"._sout(Color.White);

            //объявим словарь типа object-object
            var dict2 = new Dictionary<object, object>();
            //объявим список list1 и заполним его строчными значениями
            var list1 = new List<string>() { "q", "w", "e", "r", "t" };
            //объявим список list2 и заполим его числовыми значениями
            var list2 = new List<int>() { 1, 2, 3, 4, 5 };
            //создадим переменную счётчик
            var num = 0;
            //форичнемся по первому листу
            list1.ForEach(x =>
            {
                //в каждой итерации будем добавлять значение первого листа как ключ словаря
                //и значение по переменной-счётчику второго листа как значение словаря
                dict2.Add(x, list2[num]);
                //прибавляем к счётчику 1 при каждой итерации
                num++;
            });
            //выведем kvp словаря в консоль, то есть key value pair - пару ключ значение из словаря с помощью
            //string.Join куда передадим linq'шный Select по нашему словарю
            $"dict2 kvp: {string.Join(", ", dict2.Select(x => $"{x.Key} - {x.Value}"))}"._sout(Color.White);


            $"Press something..."._sout(Color.White);

            //инициализируем временную переменную для выхода из цикла while
            bool go = true;

            //инициализируем цикл
            while (go)
            {
                //считываем в переменную cki нажатую в консоли клавишу
                ConsoleKeyInfo cki = Console.ReadKey();

                //берём непосредственно нажатую клавишу
                ConsoleKey ck = cki.Key;
                //берём её модификаторы т.е. shift, alt либо ctrl
                ConsoleModifiers cm = cki.Modifiers;
                //проверяем что нажат shift, ctrl и alt записывая в отдельные переменные
                bool isShiftPressed = (cm & ConsoleModifiers.Shift) != 0;
                bool isCtrlPressed = (cm & ConsoleModifiers.Control) != 0;
                bool isAltPressed = (cm & ConsoleModifiers.Alt) != 0;
                //создаём строку зажатых модификаторов в которую через тернарные операторы
                //записываем все зажатые клавиши модификаторов используя ранее инициализированные булеаны
                string modifiers = $"{(isShiftPressed ? "Shift+" : "")}" +
                    $"{(isAltPressed ? "Alt+" : "")}" + 
                    $"{(isCtrlPressed ? "Ctrl+" : "")}";
                //берём char зажатой клавиши, т.е. символ
                char kc = cki.KeyChar;
                //отделяем введённую в консоль кнопку, которая там выведется
                //от вывода нашей информации о зажатой клавише
                Console.WriteLine();
                //выводим что мы зажали, с модификаторами и символом (char'ом)
                $"you pressed {modifiers}{ck}, char: {kc}"._sout(Color.Cyan);
                //если нажали клавишу Esc то меняем булеан отвечающий за продолжение цикла
                //while на false
                if (ck == ConsoleKey.Escape)
                    go = false;
            }










            //чтобы консолька сама не закрылась после выполнения всего кода выше 
            Console.ReadKey();
        }

        internal static (int, int)GetData(int[] ints)
        {
            var sum = 0;
            ints.ToList().ForEach(x => sum += x);

            var mult = 1;
            ints.ToList().ForEach(x => mult *= x);
            return (sum, mult);
        }

        internal static (Color, string)GetColor(int r, int g, int b)
        {
            var color = Color.FromArgb(r, g, b);
            return (color, color.ToString());
        }

        internal static (string, Color, int)GetColor2(int r, int g, int b)
        {
            var color = Color.FromArgb(r, g, b);
            return (color.ToString(), color, rnd.Next(0, int.MaxValue));
        }



        internal static Dictionary<int, string> ra = new Dictionary<int, string>
        { { 1000, "M" },  { 900, "CM" },  { 500, "D" },  { 400, "CD" },  { 100, "C" },
                          { 90 , "XC" },  { 50 , "L" },  { 40 , "XL" },  { 10 , "X" },
                          { 9  , "IX" },  { 5  , "V" },  { 4  , "IV" },  { 1  , "I" } };
        internal static string ToRoman(int number) => ra
        .Where(d => number >= d.Key)
        .Select(d => d.Value + ToRoman(number - d.Key))
        .FirstOrDefault();
        internal static int ToArabic(string number) => number.Length == 0 ? 0 : ra
            .Where(d => number.StartsWith(d.Value))
            .Select(d => d.Key + ToArabic(number.Substring(d.Value.Length)))
            .FirstOrDefault();

        private static void OnTicksEnded(object sender, EventArgs eargs)
        {
            if (sender is TestEvent)
            {
                var a = (eargs as TestArgs)?.@int.ToString() ?? "args is null";
                $"Message from TestEvent {a}"._sout(Color.Aqua);
            }
        }

        private static void OnHumanityChanged(object sender, EventArgs eargs)
        {
            if (sender is WeatherEvent)
            {
                var a = (eargs as WeatherArgs)?.@string ?? "args is null";
                $"Message from Weather about humanity: {a}"._sout(Color.Aqua);
            }
        }

        private static void OnTemperatureChanged(object sender, EventArgs eargs)
        {
            if (sender is WeatherEvent)
            {
                var a = (eargs as WeatherArgs)?.@string ?? "args is null";
                $"Message from Weather about temperature: {a}"._sout(Color.Orange);
            }
        }


        //делегат состоит из объявления
        //типа, возвращаемого методом
        //названия
        //и параметров метода
        //т.е. по сути делегат это Метод упакованный в переменную, которую мы можем присваивать и даже вызывать когда это необходимо
        delegate string TestDelegate(string param1, Color param2);          //тип делегата

        //сигнатура данного метода совпадает с сигнатурой делегата написанного выше
        //сигнатура это совокупность возвращаемого типа и параметров
        //названия аргументов условные, а потому могут быть разными
        static string TestMethod(string text, Color col)
        {
            $"TestMethod: {text}"._sout(col);
            return "Вызов выполнен";
        }
        
        //метод вызывающий делегат по экземпляру
        static void GarbageMethod(TestDelegate @delegate)
        {
            var result = @delegate("Тестовый вызов делегата 3", Color.Blue);
            $"GarbageMethod result: {result}"._sout(Color.Yellow);
        }

        //другой метод вызывающий делегат по экземпляру
        static string TestMethod2(string text, Color col)
        {
            $"{text} - TestMethod2"._sout(col);
            return string.Empty;
        }



























        public static bool jidfgodesughrtedogf(string str, int num, bool val)
        {
            Console.ForegroundColor = val ? Red : Green;
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine($"ConsoleTest: {str}");
            }
            Console.ForegroundColor = White;
            return !val;
        }

        public static List<Cat> kotiki;

        private static int numberOfCats = 0;

        //метод tryparse используемый в исходниках шарпа
        public static bool TryParse(string str, out int num)
        {
            try
            {
                num = int.Parse(str);
                return true;
            }
            catch
            {
                num = 0;
                return false;
            }
        }


        public static DateTime cachedTime;
        public static Random rnd = new Random();

        private static async Task CheckMyIp()
        {
            //блок итератора do while первая итерация которого выполняется всегда
            //счётчик переменной 'int i' объявляется до самого использования итератора
            //сначала выполнится тело do, после чего к i прибавится 1 и итератор прервётся
            int i = 0;
            do
            {
                Console.WriteLine();
            } while (++i < 1);

            //await - ожидание рехультата вызываемого метода (таска) 
            //и присвоение его в переменную типа таска, в данном случае MyIp
            var myIp = await IpCheck.GetMyIp();         //данный таск вернёт экземпляр типа MyIp - десериализованного json-ответа сервера моего IP


            //здесь же тело do выполнится дважды
            //в первый раз так же как и в случае выше - то есть до проверки условия
            //второй раз при подходе к условию
            //но из-за того что ++ у переменной счётчика i стоит справа - действие прибавления единицы произойдёт после выполнения
            //уже второго раза тела do
            i = 0;
            do
            {
                Console.WriteLine();
            } while (i++ < 1);

            //запуск второго таска после успешного выполнения первого
            var ip = await IpCheck.CheckIp(myIp?.ip); //данный таск вернёт экземпляр типа Ip - десериализованного json-ответа сервера 'пробивки' айпи-адреса

            //выведем форматированную при помощи $ информацию в консоль
            //обращаемся к полям нашего класса Ip куда десериализовались из json-ответа параметры ответа сервера
            Console.WriteLine($"Ip: {myIp?.ip}\n[{ip?.countryCode}] {ip?.country}, {ip?.city} ({ip?.regionName})");
        }
    }

    public static class StaticClass1
    {
        private static string _name;
        public static string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public enum CalculationType
        {
            Plus = 0,
            Minus = 1,
            Multiply = 2,
            Divide = 3
        }

        public static float Calculate(float a, float b, CalculationType type)
        {
            switch (type)
            {
                case CalculationType.Plus:
                    return a + b;
                case CalculationType.Minus:
                    return a - b;
                case CalculationType.Multiply:
                    return a * b;
                case CalculationType.Divide:
                    return a / b;
                default:
                    return 0;
            }
        }
    }

    public class NonStaticClass2
    {
        private string[] _data;
        public string[] data
        {
            get
            {
                return _data;
            }
        }
        public NonStaticClass2(string[] args)
        {
            _data = args;
        }
    }
    public class NonStaticClass1
    {
        private StaticClass1.CalculationType calcType;
        public StaticClass1.CalculationType currentType
        {
            get
            {
                return calcType;
            }
        }
        public NonStaticClass2 class2;
        private string _name;
        public string name
        {
            get
            {
                return _name;
            }
        }
        public NonStaticClass1(string n, StaticClass1.CalculationType ct)
        {
            _name = n;
            calcType = ct;
        }

        public float Calculate(float a, float b)
        {
            switch (calcType)
            {
                case StaticClass1.CalculationType.Plus:
                    return a + b;
                case StaticClass1.CalculationType.Minus:
                    return a - b;
                case StaticClass1.CalculationType.Multiply:
                    return a * b;
                case StaticClass1.CalculationType.Divide:
                    return a / b;
                default:
                    return 0;
            }
        }
    }
}
