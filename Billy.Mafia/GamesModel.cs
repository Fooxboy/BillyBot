using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Mafia
{
    public struct GamesModel
    {
        List<InfoGame> Games { get; set; }
    }

    public struct InfoGame
    {
        public int Id { get; set; }
        public long GroupId { get; set; }
        public int CountPlayers { get; set; }
        public long UserCreate { get; set; }
    }
}
