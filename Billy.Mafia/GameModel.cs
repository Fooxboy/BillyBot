using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Mafia
{
    public class GameModel
    {
        public int Id { get; set; }
        public long GroupId { get; set; }
        public List<long> FullPlayers { get; set; }
        public List<long> PlayPlayers { get; set; }
        public List<Roles.IRole> FullRoles { get; set; }
        public List<Roles.IRole> PlayRoles { get; set; }
        public long UserCreate { get; set; }
    }
}
