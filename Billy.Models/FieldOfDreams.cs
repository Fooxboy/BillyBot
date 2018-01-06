using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Models
{
    public abstract class FieldOfDreams
    {
        public abstract int Id { get; }
        public abstract string Question { get; }
        public abstract string Answer { get; }
        public abstract long Creator { get; }
        public abstract long DialogId { get; set; }
        public abstract bool Complete { get; set; }
        public abstract string Proccess { get; set; }
    }
}
