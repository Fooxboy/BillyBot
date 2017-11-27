using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Models
{
    public abstract class Bans
    {
        public abstract long Id { get; set; }
        public abstract long Time { get; set; }
        public abstract long From { get; set; }
        public abstract string Title { get; set; }
    }
}
