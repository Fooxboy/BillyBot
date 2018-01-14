using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Mafia
{
    public abstract class GameModel
    {
        public abstract int Id { get; }
        public abstract long GroupId { get; set; }
        public abstract List<long> FullPlayers { get; set; }
        public abstract List<long> PlayPlayers { get; set; }
        public abstract List<int> FullRoles { get; set; }
        public abstract List<int> PlayRoles { get; set; }
        public abstract long UserCreate { get; }
        public abstract bool isStart { get; set; }
        public abstract bool isEnd { get; set; }
    }
} 
