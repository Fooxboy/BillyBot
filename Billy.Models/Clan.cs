using System;
using System.Collections.Generic;
using System.Text;

//TODO: не нужная модель.
namespace Billy.Models
{
    public abstract class Clan
    {
        public abstract string Name { get; set; }
        public abstract int Id { get; }
        public abstract string Members { get; set; }
        public abstract long Creator { get; set; }
        public abstract string Date { get; set; }
        
    }
}
