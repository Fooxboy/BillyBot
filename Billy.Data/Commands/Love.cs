using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Data.Commands
{
    public class Love: IDataCommand
    {
        public string Name => "Любовь";
        public string Help => "Показывает процент удачи любви.";
        public string FullHelp => "ПОЛНОЕ ОПИСАНИЕ.";
        public static string Ready(string name1, string name2, int value)
        {
            string result = $"{name1} и {name2} совместимы на {value}%";
            return result;
        }
        public static string NoOneUser = "Нельзя использовать одного и того же пользователя!";
        public static string No2Forward = "Для проверки совместимости нужно переслать 2 сообщения.";
    }
}
