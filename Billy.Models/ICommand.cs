using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;

namespace Billy.Models
{
    public interface ICommand
    {
        string Help { get; }
        void Execute(Message message, string[] arguments);
        List<Enums.Billy.Donate> Donate { get;}
    }
}
