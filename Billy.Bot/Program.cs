using System;
using Billy.LongPoll;
using Billy.Commands;
using System.Threading;
using System.Collections.Generic;
using VkNet;

namespace Billy.Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Console.WriteLine("Инициализация....");
             Render.Initialization();
             Console.WriteLine("Хелло!");
             var Starter = new Starter();
                  Thread threadLongPoll = new Thread(Starter.Run);
                  threadLongPoll.Name = "LongPoll";
                  Console.WriteLine("Старт потока LongPoll");
                  threadLongPoll.Start(); */

            var hui = new Mafia.GameModel
            {
                Id = 1,
                GroupId = 2,
                FullPlayers = new List<long> { 1, 2, 3, 4, 5, 6 },
                PlayPlayers = new List<long> { 3, 4, 5, 6, 78 },
                FullRoles = new List<Mafia.Roles.IRole> { new Mafia.Roles.Алкоголик(), new Mafia.Roles.Волшебник(), new Mafia.Roles.Подросток() },
                PlayRoles = new List<Mafia.Roles.IRole> { new Mafia.Roles.Сыщик(), new Mafia.Roles.Киллер(), new Mafia.Roles.Бандит() },
                UserCreate = 3556       
            };

            var writer = new System.IO.StreamWriter(@"Mafia\Games");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(hui);
            writer.Write(json);

        }
    }
}
