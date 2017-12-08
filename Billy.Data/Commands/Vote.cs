using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Data.Commands 
{
    public class Vote : IDataCommand
    {
        public string Name => "Голосование";
        public string Help => "Команда для создания голосований.";
        public string FullHelp => "ДА ПОШОЛ ТЫ НАХУЙ.";
    }
}
