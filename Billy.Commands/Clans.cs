using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;

namespace Billy.Commands
{
    public class Clans: ICommand
    {
        Data.Commands.IDataCommand data = new Data.Commands.Clans();
        public string Name => data.Name;
        public string Help => data.Help;
        public string FullHelp => data.FullHelp;
        public List<Enums.Billy.Donate> Donate => Samples.AccessDonate.All;

        public void Execute(Message message, string[] arguments)
        {
            string result = "Неизвестная ошибка.";
            var command = arguments[2];
            switch (command)
            {
                case "создать":
                    result = Create(message.From, arguments);
                    break;
                case "вступить":
                    result = Join(message.From, arguments);
                    break;
                case "покинуть":
                    break;
                default:
                    //Неизвестная команда.
                    break;
            }
            API.Message.Send(new Models.Params.MessageSendParams
            {
                PeerId = message.PeerId,
                Message = result,
                From = message.From
            });
        }

        private string Create(long userId, string[] arguments)
        {
            string result = "Неизвестная ошибка.";
            if(arguments.Length > 3)
            {
                string name = arguments[3];
                API.Clan.New(name, userId);
            }
            else
            {
               //Не указано имя.
            }

            return result;
        }

        private string Leave(long userId, string[] arguments)
        {

        }

        private string Join(long userId, string[] arguments)
        {
            string result = "Неизвестная ошибка.";

            if(arguments.Length > 3)
            {
                var clanId = System.Convert.ToInt32(arguments[3]);
                var clan = new API.Clan(clanId);
                var members = clan.Members;
                members += $"{userId} ";
            }else
            {
                //не указан ид
            }

            return result;
        }
    }
}
