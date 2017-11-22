using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;
using Billy.Data.Commands;

namespace Billy.Commands
{
    public class About :ICommand
    {
        IDataCommand data = new Data.Commands.About();
        public string Name => data.Name;
        public string Help => data.Help;
        public string FullHelp => data.FullHelp;
        public List<Enums.Billy.Donate> Donate => Samples.AccessDonate.All;

        public void Execute(Message message, string[] arguments)
        {
            string text = Data.Commands.About.GetAbout();
            API.Message.Send(new Models.Params.MessageSendParams
            {
                PeerId = message.PeerId,
                Message = text,
                From = message.From
            });
        }
    }
}
