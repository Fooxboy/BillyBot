using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Models.Params
{
    public class BanAddParams
    {
        public long Id { get; set; }
        public long Time { get; set; }
        public long From { get; set; }
        public string Title { get; set; }
    }
}
