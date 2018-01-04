using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Data.Commands
{
    public class Clans : IDataCommand
    {
        public string Name => "Клан";
        public string Help => "Команда для работы с кланом.";
        public string FullHelp => "Олала";
    }
}
