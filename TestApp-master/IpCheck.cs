using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class MyIp                   //класс MyIp в который десериализуется ответ апи от получения нашего текущего ip
    {
        public string ip = default;     //ответ имеет лишь параметр ip, строка нашего ip с которого произвёлся запрос
    }
    public class Ip                             //класс Ip в который десериализуется ответ апи от 'пробивки' ip-адреса
    {
        public string status = default;
        public string country = default;
        public string countryCode = default;
        public string region = default;
        public string regionName = default;
        public string city = default;
        public string zip = default;
        public float lat = default;
        public float lon = default;
        public string timezone = default;
        public string isp = default;
        public string org = default;
        public string @as = default;
        public string query = default;
    }
    public class IpCheck
    {
        public static string ipUri = "http://ip-api.com/json/";                 //захардкоженный урл-адрес сервера получения нашего айпи
        public static string myIpUri = "https://api.ipify.org?format=json";     //захардкоженный урл-адрес сервера пробивки любого айпи
        
        public static async Task<MyIp> GetMyIp()
        {
            //создаём экземпляр WebRequest по нашему url'у и приводим ему к наследуемому типу HttpWebRequest
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{myIpUri}");

            //устанавливаем в поле Method метод нашего запроса - GET, т.е. получение данных
            request.Method = "GET";
            //устанавливаем в поле Accept вид принимаемого ответа нашим клиентом - json
            request.Accept = "application/json";

            //блоки try catch для избежания и обработки ошибок в запросе
            try
            {
                //сокращённая запись при помощи using класса WebResponse
                //и await асинхронного ответа сервера при помози GetResponseAsync
                using WebResponse webResponse = await request.GetResponseAsync();

                //создание экземпляра StreamReader, который в последствии прочитает пришедший поток-данных сервера,
                //от WebResponse приведённого к HttpWebResponse и получением потока стрима методом GetResponseStream()
                using StreamReader responseStreamReader = new StreamReader((webResponse as HttpWebResponse).GetResponseStream());
                
                //чтение нашего потока-стрима StreamReader методом ReadToEnd()
                string result = responseStreamReader.ReadToEnd();

                //логирование json-результата в виде строки в консоль с форматированием через $
                Console.WriteLine($"Ответ от сервера по получению нашего ip-адреса:\n{result}");

                //десериализация нашей json-строки с ответом через Newtonsoft.JsonConverter к нашему классу MyIp
                //который содержит все параметры результата;
                //при отсутствии каких-либо параметров в самой json-строке ответа - поле нашего класса
                //будет иметь default значение соответствующего типа поля
                return JsonConvert.DeserializeObject<MyIp>(result);
            }
            catch (WebException e)
            {
                //catch или же 'отлов' WebException в котором так же имеется блок try-catch
                try
                {
                    //попытка прочитать Response параметр нашего WebException через GetResponseStream()
                    //и ReadToEnd() строкой ниже
                    //параметр Response может быть null, а потому и второй Блок try-catch
                    using StreamReader exceptionStreamReader = new StreamReader(e.Response.GetResponseStream());
                    Console.WriteLine($"GetMyIp.CheckAsync error: {exceptionStreamReader.ReadToEnd()}");
                }
                catch (Exception ex2)
                {
                    //здесь мы уже берём обычный Exception и выводим его Message в случае происхождения исключения в программе
                    //при правильном написании запроса здесь программа сможет оказаться в исключительно редких случаях
                    Console.WriteLine($"GetMyIp.CheckAsync exception: {ex2.Message}");
                }
            }
            return null;

        }
        
        //аналогичный код тому что выше, с разницей лишь в приводимом типе json-строки ответа сервера
        //и сокращении написанных типов к var'ам
        public static async Task<Ip> CheckIp(string ip)
        {
            var request = (HttpWebRequest)WebRequest.Create($"{ipUri}/{ip}");
            request.Method = "GET";
            request.Accept = "application/json";
            try
            {
                using var webResponse = await request.GetResponseAsync();
                using var responseStreamReader = new StreamReader((webResponse as HttpWebResponse).GetResponseStream());
                var result = responseStreamReader.ReadToEnd();
                Console.WriteLine($"Ответ от сервера по пробивки ip-адреса:\n{result}");
                return JsonConvert.DeserializeObject<Ip>(result);
            }
            catch (WebException e)
            {
                try
                {
                    using var exceptionStreamReader = new StreamReader(e.Response.GetResponseStream());
                    Console.WriteLine($"CheckAsync.CheckAsync error: {exceptionStreamReader.ReadToEnd()}");
                }
                catch (Exception ex2)
                {
                    Console.WriteLine($"CheckAsync.CheckAsync exception: {ex2.Message}");
                }
            }
            return null;
        }

    }
}
