using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Data.Commands
{
    public class Story : IDataCommand
    {
        public string Name => "История";
        public string Help => "Рандомная интересная история.";
        public string FullHelp => "Команда для вывода разных интересных историй." +
            "\nИСПОЛЬЗОВАНИЕ:" +
            "\nБилли история"; 
    }
}
