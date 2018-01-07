using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Data.Commands
{
    public class Who : IDataCommand
    {
        public string Name => "Кто";
        public string Help => "Выберает случайного человека из беседы.";
        public string FullHelp => "Выберает рандомного человека из текущей групповой беседы." +
            "\nИСПОЛЬЗОВАНИЕ:" +
            "\nБилли Кто <название>" +
            "\nМожно только ОДНО слово.";

        public static string Ready(string name, string fam, string domain, string nick)
        {
            string text = $"И таааак. Я думаю, что [{domain}|{name} {fam}] - {nick}!";
            return text;
        }
        public static string NoChat = "Команда доступна только в групповых беседах.";
    }
}
