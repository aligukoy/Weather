using Microsoft.EntityFrameworkCore;
using WeatherAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Repositories
{
    public class WeatherDBContext:  DbContext
    {
        public WeatherDBContext(DbContextOptions<WeatherDBContext> options)
         : base(options)
        {

        }

        public DbSet<WeatherEntity> WeatherItems { get; set; }
    }
}
