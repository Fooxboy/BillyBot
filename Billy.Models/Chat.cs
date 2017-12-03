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
        public abstract long AdminChat { get;}
        //public abstract bool IsChat { get; }
        public abstract long Answer { get; set; }
        public abstract bool Blocked { get; set; }
        public abstract bool BlockedPhoto { get; set; }
        public abstract string Photo { get; set; }
        public abstract long AdminSavePhoto { get; set; }
    }
}
