using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;

namespace Billy.Commands
{
    public class When : ICommand
    {
        Data.Commands.IDataCommand data = new Data.Commands.When();
        public string Name => data.Name;
        public string Help => data.Help;
        public string FullHelp => data.FullHelp;
        public List<Enums.Billy.Donate> Donate => Samples.AccessDonate.All;

        public void Execute(Message message, string[] arguments)
        {
            string result = "Неизвестная ошибка.";

            var random = new Random();
            int day = random.Next(1, 29);
            int match = random.Next(1, 12);
            int Year = random.Next(2018, 2100);
            result = Data.Commands.When.Ready(day, match, Year);
            API.Message.Send(new Models.Params.MessageSendParams
            {
                PeerId = message.PeerId,
                Message = result,
                From = message.From
            });
        }
    }
}
