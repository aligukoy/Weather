using Newtonsoft.Json;
using WeatherAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherAPI;
using Weather.Model.Models;

namespace WeatherAPI.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {

        string host =AppSettingsManager.Settings[AppSettings.WEATHERSTACK_URL];
        

        public async Task<WeatherEntity> GetCurrentWeather(string placeOrZipCode)
        {


            var response = new WeatherEntity();
            try
            {
                using (var client = new HttpClient())
                {
                    var url = $"{host}/current?access_key={AppSettingsManager.Settings[AppSettings.WEATHERSTACK_API_KEY]}&query={placeOrZipCode}";
                    var res = await client.GetAsync(url);

                    using (HttpContent resultContent = res.Content)
                    {
                        var result = await resultContent.ReadAsStringAsync();
                        response = JsonConvert.DeserializeObject<WeatherEntity>(result);
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                return response;
            }
        }

        public async Task<WeatherEntity> GetForecast(string placeOrZipCode, int forecastDays, int interval = 1)
        {

            var response = new WeatherEntity();
            try
            {
                using (var client = new HttpClient())
                {
                    var url = $"{host}/forecast?access_key={AppSettingsManager.Settings[AppSettings.WEATHERSTACK_API_KEY]}&query={placeOrZipCode}&forecast_days=forecastDays";
                    var res = await client.GetAsync(url);

                    using (HttpContent resultContent = res.Content)
                    {
                        var result = await resultContent.ReadAsStringAsync();
                        response = JsonConvert.DeserializeObject<WeatherEntity>(result);
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                return response;
            }

        }
    }
}
