using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;

namespace Billy.Models
{
    public interface ICommand
    {
        string Name { get; }
        string Help { get; }
        string FullHelp { get; }
        void Execute(Message message, string[] arguments);
        List<Enums.Billy.Donate> Donate { get;}
    }
}
