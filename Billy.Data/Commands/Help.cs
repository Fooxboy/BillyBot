using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Data.Commands
{
    public class Help : IDataCommand
    {
        public string Name => "Помощь";
        string IDataCommand.Help => "Выводит список команд.";
        public string FullHelp => "Выводит список команд.";
    }
}
