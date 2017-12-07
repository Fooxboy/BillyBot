using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Data.Commands
{
    public class When : IDataCommand
    {
        public string Name => "Когда";
        public string Help => "Скажет Вам нужную дату.";
        public string FullHelp => "Команда предназначена для угадывания даты." +
            "\nИСПОЛЬЗОВАНИЕ:" +
            "\nБилли когда <событие>";
        public static string Ready(int day, int Motch, int Year)
        {
            string text = $"Это произойдёт {day}.{Motch}.{Year}";
                return text;
        }
    }
}
