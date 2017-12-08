using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;

namespace Billy.Commands
{
    public class Hello : ICommand
    {
        public string Name => "Привет";
        public string Help => "Отладочная команда.";
        public string FullHelp => "Полное описание";
        public List<Enums.Billy.Donate> Donate => Samples.AccessDonate.All;

        public void Execute(Message message, string[] arguments)
        {
            API.Message.Send(new Models.Params.MessageSendParams
            {
                PeerId = message.PeerId,
                Message = "привет",
                From = message.From
            });
        }
    }
}
