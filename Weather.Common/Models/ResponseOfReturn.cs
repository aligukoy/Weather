using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Model.Models;

namespace Weather.Model.Models
{
    public sealed class Response<TReturn> : Response
    {
        public TReturn Object { get; set; }
    }
}
