using System;
using System.Collections.Generic;
using System.Text;

namespace Billy.Data.Commands
{
    public class Meme : IDataCommand
    {
        public string Name => "Мем";
        public string Help => "Отсылает рандомный мем.";
        public string FullHelp => "Команда для получения мемоооооооооооооов." +
            "\nИСПОЛЬЗОВАНИЕ:" +
            "\nБилли мем";
    }
}
