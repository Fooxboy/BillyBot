using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;

namespace Billy.Commands
{
    public class Mafia: ICommand
    {
        Data.Commands.IDataCommand data = new Data.Commands.Who();
        public string Name => data.Name;
        public string Help => data.Help;
        public string FullHelp => data.FullHelp;
        public List<Enums.Billy.Donate> Donate => Samples.AccessDonate.All;

        //TODO: Доделать класс мафии
        public void Execute(Message message, string[] arguments)
        {

        }
    }
}
