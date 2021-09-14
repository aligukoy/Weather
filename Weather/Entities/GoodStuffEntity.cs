using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Entities
{
    public class GoodStuffEntity
    {
        public string GoodStuff { get; set; }


        public static GoodStuffEntity GetGoodStuff(bool yesGiveItToMe)
        {
            return new GoodStuffEntity()
            {
                GoodStuff = "Never",
            };
        }
    }
}
