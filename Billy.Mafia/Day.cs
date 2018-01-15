using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Billy.Mafia
{
    public class Day
    {
        //Начало дня.
        public static void Api(int gameId)
        {
            //начало дня.

            //И так игроки! Начался день! День длится  120 секунд. За это время можно проголосовать.
            var game = new Game(gameId);
            string members = "";
            int i = 1;
            var vk = API.Data.GetVk();
            foreach(var player in game.PlayPlayers)
            {
                var list = new List<long>();
                list.Add(player);
                var user = vk.Users.Get(list)[0];
                members += $"{i} - {user.FirstName} {user.LastName} \n"; 
            }

            foreach(var member in game.PlayPlayers)
            {
                API.Message.Send(new Models.Params.MessageSendParams
                {
                    PeerId = member,
                    Message = $"Как ты думаешь, кто у нас злодей? Голосуй за того! Чтобы проголосовать, напиши: Билли, мафия голосовать ПОРЯДКОВЫЙ_НОМЕР\n {members}",
                    From = member
                });
            }

            //Осталось времени.. бла бла бла.

            //конец ночи.

            string choisedMemers = "";

            using (StreamReader sr = new StreamReader($"Mafia_{game.Id}.json"))
            {
                choisedMemers = sr.ReadToEnd();
            }
            List<long> choisedList = new List<long>(); 
            var choisedArray = choisedMemers.Split(' ');
            foreach (var choisedMember in choisedArray) choisedList.Add(Int64.Parse(choisedMember));

            var choisedUser = choisedList.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;

            var list2 = new List<long>();
            list2.Add(choisedUser);
            var user2 = vk.Users.Get(list2)[0];
            int j = 0;
            for( ; game.PlayPlayers.Count > j; j++)
            {
                if (game.PlayPlayers[j] == choisedUser) break;
            }

            //И У НАС СЕГОДНЯ УМИРАЕТ {user.FirstName} Он был {game.PlayRoles.ToArray[j]}! 

        }
    }
}
