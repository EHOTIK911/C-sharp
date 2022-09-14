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
    public class Sys
    {
        public string country = default;
        public long sunrise = default;
        public long sunset = default;
    }
    public class Clouds
    {
        public float all = default;
    }
    public class Wind
    {
        public float speed = default;
        public float deg = default;
        public float gust = default;
    }
    public class Main
    {
        public float temp = default;
        public float feels_like = default;
        public float temp_min = default;
        public float temp_max = default;
        public float pressure = default;
        public float humidity = default;
        public float sea_level = default;
        public float grnd_level = default;
    }
    public class WeatherData
    {
        public float id = default;
        public string main = default;
        public string description = default;
        public string icon = default;
    }
    public class Coords
    {
        public float lon = default;
        public float lat = default;
    }
    public class Weather
    {
        public Coords coord = default;
        public WeatherData[] weather = default;
        public string @base = default;
        public Main main = default;
        public float visibility = default;
        public Wind wind = default;
        public Clouds clouds = default;
        public float dt = default;
        public Sys sys = default;
        public float timezone = default;
        public float id = default;
        public string name = default;
        public float cod = default;

        public const float kelvinConst = 273.15f;
        public float CurrentTemp
        {
            get => main.temp - kelvinConst;
        }
        public float MinTemp
        {
            get => main.temp_min - kelvinConst;
        }
        public float MaxTemp
        {
            get => main.temp_max - kelvinConst;
        }
        public string WeatherStatus
        {
            get => weather[0].description;
        }
        public float FeelsLike
        {
            get => main.feels_like - kelvinConst;
        }
        public string City
        {
            get => $"[{sys.country}] {name}";
        }
        public DateTime Sunrise
        {
            get
            {
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dateTime = dateTime.AddSeconds(sys.sunrise).ToLocalTime();
                return dateTime;
            }
        }
        public DateTime Sunset
        {
            get
            {
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dateTime = dateTime.AddSeconds(sys.sunset).ToLocalTime();
                return dateTime;
            }
        }   
        public string WindDirection
        {
            get
            {
                var deg = wind.deg;
                if (deg >= 338 || deg <= 23)
                    return "North";
                else if (deg >= 23 && deg <= 68)
                    return "North-East";
                else if (deg >= 68 && deg <= 113)
                    return "East";
                else if (deg >= 113 && deg <= 158)
                    return "South-East";
                else if (deg >= 158 && deg <= 203)
                    return "South";
                else if (deg >= 203 && deg <= 248)
                    return "South-West";
                else if (deg >= 248 && deg <= 293)
                    return "West";
                else if (deg >= 293 && deg <= 338)
                    return "North-West";
                else
                    return "N/A";
            }
        }

        public float WindSpeed
        {
            get => wind.speed;
        }
    }

    public static class WeatherCheck
    {
        public static string apiKey = "";

        public static string GetAPIUri() => $"http://api.openweathermap.org/data/2.5/weather?appid={apiKey}&q=";

        public static async Task<Weather> CheckWeather(string city)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                Console.WriteLine("Введите open-weather apikey (получить c https://home.openweathermap.org/api_keys):");
                apiKey = Console.ReadLine();
            }
            Console.WriteLine($"{GetAPIUri()}{city}");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{GetAPIUri()}{city}");
            request.Method = "GET";
            request.Accept = "application/json";
            try
            {
                using WebResponse webResponse = await request.GetResponseAsync();
                using StreamReader responseStreamReader = new StreamReader((webResponse as HttpWebResponse).GetResponseStream());
                var a = responseStreamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<Weather>(a);
            }
            catch (WebException e)
            {
                try
                {
                    using StreamReader exceptionStreamReader = new StreamReader(e.Response.GetResponseStream());
                    Console.WriteLine($"Weather.GetWeather error: {exceptionStreamReader.ReadToEnd()}");
                }
                catch (Exception ex2)
                {
                    Console.WriteLine($"Weather.GetWeather exception: {ex2.Message}");
                }
            }
            return null;

        }
    }
}
