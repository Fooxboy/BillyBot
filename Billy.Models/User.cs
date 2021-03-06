using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Models
{
    public abstract class User
    {
        public abstract long Id { get;}
        public abstract string Name { get; set; }
        //public abstract bool Is { get; }
        public abstract int Foxs { get; set; }
        public abstract bool Ban { get; set; }
        public abstract string DateRegistation { get; }
        public abstract int CountMessage { get; set; }
        public abstract bool Settings { get; set; }
        public abstract Enums.Billy.Donate Donate { get; set; }
        public abstract int DonateCount { get; set; }
        public abstract int Clan { get; set; }
        public abstract int FieldOfDreams { get; set; }
        public abstract int Mafia { get; set; }
    }
}
