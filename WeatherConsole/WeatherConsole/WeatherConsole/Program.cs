using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Weather.Model.Models;
using System.Linq;
using System.Media;

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

                Console.WriteLine("Another One?: Y/N");

            } while (string.Equals(Console.ReadLine(), "Y", StringComparison.CurrentCultureIgnoreCase));

            
             Console.WriteLine("Want the good stuff (Y/N)?");
            var yes = string.Equals(Console.ReadLine(), "Y", StringComparison.CurrentCultureIgnoreCase);
            if (yes)
                GetGoodStuff();

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

        public static void GetGoodStuff()
        {

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "rr.txt";
            
            string r = assembly.GetManifestResourceNames().Single(x => x.EndsWith(resourceName));


            string rr;

            using (Stream stream = assembly.GetManifestResourceStream(r))
            {
                using (var reader = new StreamReader(stream))
                {
                    rr= reader.ReadToEnd();
                }
            }
           
            

            using (StringReader reader = new StringReader(rr))
            {
                string line = string.Empty;
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
                        Console.WriteLine(line);
                    }
                } while (line != null);
            }


            var rrLocation = Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            SoundPlayer player = new SoundPlayer();
            string rrsound = rrLocation.Single(x =>x.EndsWith("rr.wav"));
            player.SoundLocation = rrsound;
            player.Play();

            Console.ReadLine();
        }
    }
}
