using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Models
{
    public struct DailyMissionsChatModel
    {
        public long Count { get; set; }
        public List<long> Chats { get; set; }
    }
}
