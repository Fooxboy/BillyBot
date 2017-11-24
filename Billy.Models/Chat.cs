using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Models
{
    public abstract class Chat
    {
        public abstract long Id { get; }
        public abstract string Name { get; set; }
        public abstract long AdminSave { get; set; }
        public abstract long AdminChat { get; set; }
        //public abstract bool IsChat { get; }
        public abstract long Answer { get; set; }
        public abstract bool Blocked { get; set; }
    }
}
