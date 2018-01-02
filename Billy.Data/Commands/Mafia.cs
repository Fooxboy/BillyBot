using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Data.Commands
{
    public class Mafia : IDataCommand
    {
        public string Name => "Мафия";
        public string Help => "Игра в мафию.";
        public string FullHelp => "Команда для игры в мафию все правила можно прочитать написав:";
    }
}
