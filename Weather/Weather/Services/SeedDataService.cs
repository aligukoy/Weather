using WeatherAPI.Entities;
using WeatherAPI.Repositories;
using System;
using System.Threading.Tasks;

namespace WeatherAPI.Services
{
    public class SeedDataService : ISeedDataService
    {
        public async Task Initialize(WeatherDBContext context)
        {
            context.WeatherItems.Add(new WeatherEntity());
            

            await context.SaveChangesAsync();
        }
    }
}
