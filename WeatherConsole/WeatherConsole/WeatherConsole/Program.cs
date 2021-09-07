using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Weather.Model.Models;

namespace WeatherConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            AskTheWeather();
        }

        public async static void AskTheWeather()
        {

            Console.WriteLine("NOTE: Run the API first \n");

            Console.WriteLine("Welcome to Weather Console.");


            do
            {
                Console.WriteLine("Enter Place or ZipCode");
                var zip = Console.ReadLine();
                var weatherReport = await GetWeather(zip);
                Console.WriteLine(weatherReport);

                Console.WriteLine("\nAnother One?: Y/N");

            } while (string.Equals(Console.ReadLine(), "Y", StringComparison.CurrentCultureIgnoreCase));

            Console.WriteLine("DONT open this url: https://www.youtube.com/watch?v=dQw4w9WgXcQ&ab");
            Console.ReadLine();

        }

        public async static Task<string> GetWeather(string zipCode)
        {

       

            string weatherResponse = "";
            try
            {
                using (var client = new HttpClient())
                {
                    var url = $"https://localhost:44378/api/v1/weather/getweather/{zipCode}";
                    var result = client.GetAsync(url).Result;
                    using (HttpContent resultContent = result.Content)
                    {
                        var res = await resultContent.ReadAsStringAsync();
                        Response<WeatherDto> weatherDto = JsonConvert.DeserializeObject<Response<WeatherDto>>(res);
                        WeatherDto weather = weatherDto.Object;

                        if (weatherDto.Errored)
                        {
                            return "Failed To Get weather for this Zip Code or Place.";
                        }

                        var allWeatherDescription = string.Join("\n", weather.weather_descriptions);
                        string shouldGoOutside = $"{allWeatherDescription}.\n[The response from weatherstack does not indicate wether its currently raining or not. However, you can get a forecast for the next 24 hours, and see if theres a CHANCE of raining]\n";
                        string shouldWearSunscreen = weather.uv_index > 3 ? "Yes" : "No";
                        string canFlyKite = weather.wind_speed > 15 ? "Yes" : "No";


                        weatherResponse += $"=========== Weather Report for {weather.name}, {weather.country} ===========\n";
                        weatherResponse += $"Should I go outside? : {shouldGoOutside}\n";
                        weatherResponse += $"Should I wear sunscreen? : {shouldWearSunscreen}\n";
                        weatherResponse += $"Can I fly a kite? : {canFlyKite}\n";
                        

                        return weatherResponse;
                    }
                }
                
            
            }
            catch (Exception ex)
            {
                return "Something went wrong, make sure API is running";
            }
        }
    }
}
