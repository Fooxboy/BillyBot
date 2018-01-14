using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Mafia
{
    public class Start
    {
        public static string Result(long chatId, long userId, int gameId)
        {
            if (!Game.Is(gameId)) return "Неверный ID игры!";
            var game = new Game(gameId);
            if (game.isStart) return "Игра уже была начата!";
            if (game.isEnd) return "Игра была уже завершена!";
            int countPlayers = game.FullPlayers.Count;
            if (countPlayers < 5) return "Количество игроков должно быть больше либо равно 5.";
            ApiStart(gameId);
            return "Игра успешно начата! Сейчас Вам в Личные сообщения отправилось сообщение с Вашей ролью и кратким описанием.";
        }
        public static void ApiStart(int gameId)
        {
            var game = new Game(gameId);
            var roles = RandomRoles(game.FullPlayers.Count);
            game.FullRoles = roles;
            game.PlayRoles = roles;
            game.isStart = true;
            var members = game.FullPlayers;
            for(int i=0; members.Count > i; i++)
            {
                var member = members[i];
                var role = Roles.All.Get(game.FullRoles.ToArray()[i]);

                API.Message.Send(new Models.Params.MessageSendParams
                {
                    PeerId = member,
                    Message = role.Message,
                    From = member
                });
            }
        }

        private static List<int> RandomRoles(int count)
        {
            var random = new Random();

            var arrayRoles = new int[count];
            for (int i = 0; arrayRoles.Length > i; i++) arrayRoles[i] = random.Next(1, 10);
            List<int> roles = new List<int>();
            foreach (var role in arrayRoles) roles.Add(role);
            return roles;         
        }
    }
}
