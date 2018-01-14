using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Mafia
{
    public class Join
    {
        public static string Result(long userId, long ChatId, int gameId)
        {
            var user = new API.User(userId);
            if (user.Mafia != 0) return "Вы уже находитесь в другой игре! Выйдите с неё или ждите её окончания.";
            if (!Game.Is(gameId)) return "Неверный ID игры!";
            var game = new Game(gameId);
            if (game.GroupId != ChatId) return "Эта игра привязана к другому диалогу!";

            var members = game.FullPlayers;
            if (members.Count >= 10) return "Достигнуто масимальное кол-во игроков.";
            members.Add(userId);
            game.FullPlayers = members;
            game.PlayPlayers = members;
            user.Mafia = gameId;
            if (game.FullPlayers.Count == 10) return "СТАРТ!";
            return $"Вы успешно присоединились к игре! Если игроков будет больше 10, тогда игра автоматически начнётся. Если хотите вручную начать, создатель должен написать : Билли мафия старт {gameId}";
        }
    }
}
