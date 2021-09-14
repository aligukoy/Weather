using System;
using System.Runtime.Serialization;


namespace WeatherAPI.Helpers
{
    [Serializable]
    public class SecurityExceptions : Exception
    {
        public SecurityExceptions(string msg) : base(msg)
        {
            
        }

        protected SecurityExceptions(SerializationInfo info, StreamingContext context)
        : base(info, context)
        {
        }
    }
}
