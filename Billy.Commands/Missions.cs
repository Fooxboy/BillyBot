using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;

namespace Billy.Commands
{
    class Missions:ICommand
    {
        Data.Commands.IDataCommand data = new Data.Commands.Who();
        public string Name => data.Name;
        public string Help => data.Help;
        public string FullHelp => data.FullHelp;
        public List<Enums.Billy.Donate> Donate => Samples.AccessDonate.All;

        public void Execute(Message message, string[] arguments)
        {
            string result = "Неизвестная ошибка.";

            if(arguments.Length < 3)
            {
                //не указана подкоманда
            }else
            {
                var command = arguments[2];

                switch(command.ToLower())
                {
                    case "создать":
                        break;
                    case "список":
                        break;
                    case "статус":
                        break;
                    case "проверить":
                        break;
                    default:
                        //неверная подкомадна
                        break;
                }
            }

            API.Message.Send(new Models.Params.MessageSendParams
            {
                PeerId = message.PeerId,
                Message = result,
                From = message.From
            });
        }

        private string Create(Message message, string[] arguments)
        {
            string result = "Неизвестная ошибка.";

            int count = arguments.Length;

            return result;
        }

    }
}
