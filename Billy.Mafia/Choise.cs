using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Billy.Mafia
{
    public class Choise
    {
        public static string Result(long userId, long chatId, int userChoise)
        {
            var user = new API.User(userId);
            if (user.Mafia == 0) return "Вы не находитесь в какой-либо игре.";
            if (!Game.Is(user.Mafia)) return "Игра, в которой Вы находитесь не существует.";
            var game = new Game(user.Mafia);
            if (!game.isStart) return "Игра, в которую вы присоединились, ещё не начата.";
            if (!game.isEnd) return "Игра уже окончена.";
            if(!File.Exists($"Mafia_{game.Id}.json")) File.Create($"Mafia_{game.Id}.json");
            string result = "";
            using (StreamReader sr = new StreamReader($"Mafia_{ game.Id }.json"))
            {
                result = sr.ReadToEnd();
            }
            var choises = result.Split(' ');
            List<long> choisesList = new List<long>();
            foreach (var choise in choises) choisesList.Add(Int64.Parse(choise));
            var arrayMembers = game.PlayPlayers.ToArray();
            choisesList.Add(arrayMembers[userChoise]);
            string resultWrite = "";
            foreach (var choise in choisesList) resultWrite += $"{choise} ";
            using (StreamWriter sw = new StreamWriter($"Mafia_{game.Id}.json", false, Encoding.Default))
            {
                sw.Write(resultWrite);
            }
            return "Вы успешно проголосовали!";
        }
    }
}
