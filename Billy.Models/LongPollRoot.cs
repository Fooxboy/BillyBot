using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Models
{
    public class LongPollRoot
    {
        public string Ts { get; set; }
        public List<List<object>> Updates { get; set; }
    }
}
