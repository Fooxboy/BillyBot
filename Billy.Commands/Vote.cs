using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;

namespace Billy.Commands
{
    public class Vote : ICommand
    {
        Data.Commands.IDataCommand data = new Data.Commands.Foxs();
        public string Name => data.Name;
        public string Help => data.Help;
        public string FullHelp => data.FullHelp;
        public List<Enums.Billy.Donate> Donate => Samples.AccessDonate.Premuim;

        public void Execute(Message message, string[] arguments)
        {
            string result = "Неизвестная ошибка.";
            var user = new API.User(message.From);
            bool access = false;
            foreach(var donate in Donate)
            {
                if(donate == user.Donate)
                {
                    access = true;
                    break;
                }
            }
            if(access)
            {
                if(arguments.Length <3)
                {
                    //не указана подкоманда.
                }else
                {
                    string command = arguments[2];
                    switch (command.ToLower())
                    {
                        case "создать":
                            break;
                        case "выбор":
                            break;
                        default:
                            //неверная подкоманда
                            break;
                    }
                }        
            }else
            {
                //нет доступа.
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

            return result;
        }
    }
}
