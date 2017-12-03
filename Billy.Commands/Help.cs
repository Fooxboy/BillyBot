using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;

namespace Billy.Commands
{
    public class Help : ICommand
    {
        Data.Commands.IDataCommand data = new Data.Commands.Help();
        public string Name => data.Name;
        string ICommand.Help => data.Help;
        public string FullHelp => data.FullHelp;
        public List<Enums.Billy.Donate> Donate => Samples.AccessDonate.All;

        public void Execute(Message message, string[] arguments)
        {
            string result = " ";

            var commands = Render.Commands;

            foreach(var command in commands)
            {
                result += $"\n{command.Name} - {command.Help}";
            }

            API.Message.Send(new Models.Params.MessageSendParams
            {
                PeerId = message.PeerId,
                Message = result,
                From = message.From
            });
        }
    }
}
