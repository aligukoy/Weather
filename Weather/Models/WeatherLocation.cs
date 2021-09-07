using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Models
{
    public class WeatherLocation
    {
        public string  name { get; set; }
        public string country { get; set; }
        public string region { get; set; }
        public string lat { get; set; }
        public  string lon { get; set; }
        public string timezone_id { get; set; }
        public string localtime { get; set; }
        
        public string utc_offset { get; set; }
    }
}
