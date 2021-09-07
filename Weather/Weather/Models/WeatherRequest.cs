using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Models
{
    public class WeatherRequest
    {
       public  string type { get; set; }
       public string query { get; set; }
       public string language { get; set; }
       public string unit { get; set; }
    }
}
