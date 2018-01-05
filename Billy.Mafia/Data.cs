using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Billy.Mafia
{
    public class Data
    {
        public static void Read()
        {

        }

        public static void WriteGameAll(GameModel game)
        {
            var nowGames = "";
        }

        public static void Create(long chat_id)
        {         
            File.Create($@"Mafia\game_{chat_id}.json");
        }
    }
}
