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
                switch (command.ToLower())
                {
                    case "создать":
                        result = Create(message.From, arguments, message);
                        break;
                    case "отв":
                        result = CreateAnswer(message.From, message, arguments);
                        break;
                    case "войти":
                        result = Enter(message.From, message, arguments, API.Converter.ToChatId(message.PeerId));
                        break;
                    case "выйти":
                        result = Leave(message);
                        break;
                    case "буква":
                        result = Char(message, arguments);
                        break;
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

        private string Leave(Message message)
        {
            string result = "Неизвестная ошибка.";

            if(message.Type == Enums.LongPoll.TypeMessage.Chat)
            {

                var user = new API.User(message.From);
                if(user.FieldOfDreams != 0)
                {
                    user.FieldOfDreams = 0;
                    result = Data.Commands.FieldOfDreams.ReadyLeave;
                }
                else result = Data.Commands.FieldOfDreams.InNotGame;
            }
            else result = Data.Commands.FieldOfDreams.InDialog;

            return result;
        }

        private string Enter(long userId, Message message, string[] arguments, long dialogId)
        {
            string result = "Неизвестная ошибка.";

            if (message.Type == Enums.LongPoll.TypeMessage.Chat)
            {
                if (arguments.Length == 4)
                {
                    var id = Int32.Parse(arguments[3]);

                    if (API.FieldOfDreams.Is(id))
                    {
                        var game = new API.FieldOfDreams(id);
                        var user = new API.User(userId);

                        if (game.Answer != "нет")
                        {
                            if (!game.Complete)
                            {
                                if (game.DialogId == 0)
                                {
                                    if (game.Creator == userId)
                                    {
                                        game.DialogId = dialogId;
                                        user.FieldOfDreams = id;
                                        result = Data.Commands.FieldOfDreams.ReadyAdded;
                                    }
                                    else result = Data.Commands.FieldOfDreams.IsNotCreatorAdd;
                                } 
                                else
                                {
                                    if (game.DialogId == dialogId)
                                    {
                                        if (user.FieldOfDreams == 0)
                                        {
                                            user.FieldOfDreams = id;
                                            result = Data.Commands.FieldOfDreams.ReadyEnter;
                                        }
                                        else result = Data.Commands.FieldOfDreams.UserInPlayOther;
                                    }
                                    else result = Data.Commands.FieldOfDreams.GameInChatId;
                                }
                            }
                            else result = Data.Commands.FieldOfDreams.GameEnd;
                        }
                        else result = Data.Commands.FieldOfDreams.NoStarted;
                    } else result = Data.Commands.FieldOfDreams.NoId;
                }
                else result = Data.Commands.FieldOfDreams.NotId;
            } else result = Data.Commands.FieldOfDreams.InChat;

            return result;
        }

        private string Char(Message message, string[] arguments)
        {
            string result = "Неизвестная ошибка.";

            if(message.Type == Enums.LongPoll.TypeMessage.Chat)
            {

                if (arguments.Length == 4)
                {
                    var user = new API.User(message.From);
                    if (user.FieldOfDreams != 0)
                    {
                        var game = new API.FieldOfDreams(user.FieldOfDreams);

                        if (!game.Complete)
                        {
                            if (game.DialogId == API.Converter.ToChatId(message.PeerId))
                            {

                                var letterChar = Convert.ToChar(arguments[3].ToLower());
                                var answerArray = game.Answer.ToCharArray();
                                var proccessArray = game.Proccess.Split(' ');
                                int countLetter = 0;
                                for (int i = 0; answerArray.Length > i; i++)
                                {
                                    if (answerArray[i] == letterChar)
                                    {
                                        proccessArray[i] = $"[{answerArray[i]}]";
                                        countLetter += 1;
                                    }
                                }

                                if (countLetter != 0)
                                {
                                    var resultProccess = "";

                                    foreach (var proccess in proccessArray) resultProccess += $"{proccess} ";
                                    game.CountChar -= countLetter;
                                    if (game.CountChar == 0 || game.CountChar < 0)
                                    {
                                        //игра закончена.
                                        game.Complete = true;
                                    }

                                    result = Data.Commands.FieldOfDreams.ReadyWin(countLetter, resultProccess, game.Complete);
                                }
                                else result = Data.Commands.FieldOfDreams.ReadyLose;

                            }
                            else result = Data.Commands.FieldOfDreams.GameInChatId;
                        } else result = Data.Commands.FieldOfDreams.GameIsComptele;
                    } else result = Data.Commands.FieldOfDreams.InNotGame;
                } else result = Data.Commands.FieldOfDreams.NoChar;

            }
            else result = Data.Commands.FieldOfDreams.InChat;

            return result;
        }

        private string Create(long userId, string[] arguments, Message message)
        {
            var result = "Неизвестная ошибка.";

            if (message.Type == Enums.LongPoll.TypeMessage.Dialog)
            {
                if (arguments.Length < 3)
                {
                    var quest = "";
                    for (int i = 3; arguments.Length > i; i++) quest += $"{arguments[i]} ";
                    var id = API.FieldOfDreams.New(quest, userId);

                    result = Data.Commands.FieldOfDreams.ReadyCreate(id);
                }
                else result = Data.Commands.FieldOfDreams.NoQuesstion;
            }
            else result = Data.Commands.FieldOfDreams.InDialog;
            return result;
        }

        private string CreateAnswer(long userId, Message message, string[] argumetns)
        {
            string result = "Неизвестная ошибка.";

            if (message.Type == Enums.LongPoll.TypeMessage.Dialog)
            {
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
                            game.CountChar = count;
                            result = Data.Commands.FieldOfDreams.ReadyCreateAnswer;
                        }
                        else result = Data.Commands.FieldOfDreams.NoCreator;
                    }
                    else result = Data.Commands.FieldOfDreams.NoId;
                }
                else result = Data.Commands.FieldOfDreams.NoIdOrAnwser;
            }
            else result = Data.Commands.FieldOfDreams.InDialog;
            return result;
        }
    }
}
