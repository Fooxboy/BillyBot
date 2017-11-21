using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;

namespace Billy.Commands
{
    public class Test : ICommand
    {

        public string Help => "хуй";

        public void Execute(Message message, string[] arguments)
        {

        }
        public List<Enums.Billy.Donate> Donate => new List<Enums.Billy.Donate> { };


    }
}
