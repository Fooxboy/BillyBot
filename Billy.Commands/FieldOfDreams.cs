using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;

namespace Billy.Commands
{
    public class FieldOfDreams: ICommand
    {
        Data.Commands.IDataCommand data = new Data.Commands.FieldOfDreams();
        public string Name => data.Name;
        public string Help => data.Help;
        public string FullHelp => data.FullHelp;
        public List<Enums.Billy.Donate> Donate => Samples.AccessDonate.All;

        public void Execute(Message message, string[] arguments)
        {
            string result = "Неизвестная ошибка.";

            if (arguments.Length > 2)
            {
                var command = arguments[2];
                switch (command)
                {
                    case "создать":
                        result = Create(message.From, arguments);
                        break;
                    case "отв":
                        result = CreateAnswer(message.From, arguments);
                        break;
                    case "зайти":
                    default:
                        //Неизвестная подкоманда
                        break;
                }
            }
            else result = Data.Commands.FieldOfDreams.NotCommand;

            API.Message.Send(new Models.Params.MessageSendParams
            {
                PeerId = message.PeerId,
                Message = result,
                From = message.From
            });
        }


        private string Out(long userId, string[] arguments, long dialogId)
        {
            string result = "Неизвестная ошибка.";

            return result;
        }

        private string Create(long userId, string[] arguments)
        {
            var result = "Неизвестная ошибка.";

            if (arguments.Length < 3)
            {
                var quest = "";
                for (int i = 3; arguments.Length > i; i++) quest += $"{arguments[i]} ";
                var id = API.FieldOfDreams.New(quest, userId);
                result = Data.Commands.FieldOfDreams.ReadyCreate(id);

            }
            else result = Data.Commands.FieldOfDreams.NoQuesstion;

            return result;
        }

        private string CreateAnswer(long userId, string[] argumetns)
        {
            string result = "Неизвестная ошибка.";

            if (argumetns.Length == 5)
            {
                var id = Int32.Parse(argumetns[3]);
                var answer = argumetns[4];

                if (API.FieldOfDreams.Is(id))
                {
                    var game = new API.FieldOfDreams(id);
                    if (game.Creator == userId)
                    {
                        int count = answer.Length;
                        var proccess = "";
                        for (int i = 0; count < i; i++) proccess += "[?] ";
                        game.Proccess = proccess;
                        result = Data.Commands.FieldOfDreams.ReadyCreateAnswer;
                    }
                    else result = Data.Commands.FieldOfDreams.NoCreator;
                }
                else result = Data.Commands.FieldOfDreams.NoId;
            }
            else result = Data.Commands.FieldOfDreams.NoIdOrAnwser;

            return result;
        }
    }
}
