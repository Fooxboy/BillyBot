using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Data.Commands
{
    public class Lot : IDataCommand
    {
        public string Name => "Жребий";
        public string Help => "Выберает одного из нескольких.";
        public string FullHelp => "Выберает одного пользователя из нескольких." +
            "\nИСПОЛЬЗОВАНИЕ:" +
            "\nБилли жребий (2 и более пересланных сообщений)";
        public static string Ready(string name, string name2)
        {
            string text = $"И я выбираю {name} {name2}!";
            return text;
        }
        public static string NoForward = "Количество пересланных сообщений должно быть 2 и выше!";
    }
}
