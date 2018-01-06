using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Data.Commands
{
    public class FieldOfDreams : IDataCommand
    {
        public string Name => "Пч";
        public string Help => "Игра в Поле Чудес! ";
        public string FullHelp => "Полное описание.";
    }
}
