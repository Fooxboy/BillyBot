using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;
using Billy.Data.Commands;

namespace Billy.Commands
{
    public class Test : ICommand
    {
        IDataCommand data = new Data.Commands.Test();
        public string Name => data.Name;
        public string Help => data.Help;
        public string FullHelp => data.FullHelp;
        public List<Enums.Billy.Donate> Donate => Samples.AccessDonate.All;

        public void Execute(Message message, string[] arguments)
        {
            var hul = Data.Commands.Test.Complete;
        }
    }
}
