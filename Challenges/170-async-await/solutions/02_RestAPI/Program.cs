using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

class Program
{
    static async Task Main(string[] args)
    {
        string city = "Leipzig";
        var weather = await GetWeather(city);
        Console.WriteLine($"In {city} ist es {weather.description} bei {weather.temperature} und {weather.wind} Wind");

        Console.ReadKey();
    }

    static async Task<WeatherData> GetWeather(string city)
    {
        using (var client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync($"https://goweather.herokuapp.com/weather/{city}");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WeatherData>(jsonString);
            }

            throw new InvalidOperationException(response.StatusCode.ToString());
        }
    }

    record WeatherData(string temperature, string wind, string description);
}
