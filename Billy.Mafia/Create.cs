using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Mafia
{
    /// <summary>
    /// Создать игру.
    /// </summary>
    public class Create
    {
        public static string Result(long userId, long ChatId)
        {
            var user = new API.User(userId);
            if (user.Mafia != 0) return "Вы уже находитесь в игре.";
            var gameId = Game.New(ChatId, userId);
            return $"Вы успешно создали игру! Чтобы другие смогли к ней присоединиться они должны написать: Билли мафия войти {gameId}";
        }
    }
}
