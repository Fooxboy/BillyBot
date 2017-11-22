using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Data.Commands
{
    public class About : IDataCommand
    {
        public string Name => "Оботе";
        public string Help => "Выводит информацию о боте";
        public string FullHelp => "Выводи полную информацию о сборке, версии, дате сборки, разработчика и т.д";
        public static string GetAbout()
        {
            string text = $"Билли бот." +
                $"\nВерсия: {Billy.Version}." +
                $"\nДата последней сборки: {Billy.Build}." +
                $"\nРазработчик: [fooxboy|Славик Смирнов]." +
                $"\nПо всем вопросам обращаться к нему.";
            return text;
        }
    }
}
