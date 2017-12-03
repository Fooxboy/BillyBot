using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;

namespace Billy.Commands
{
    public class Chat :ICommand
    {
        Data.Commands.IDataCommand data = new Data.Commands.Chat();
        public string Name => data.Name;
        public string Help => data.Help;
        public string FullHelp => data.FullHelp;
        public List<Enums.Billy.Donate> Donate => Samples.AccessDonate.Vip;
        
        public void Execute(Message message, string[] arguments)
        {
            string result = "Неизвестная ошибка.";
            if(message.Type == Enums.LongPoll.TypeMessage.Chat)
            {
                if (!API.Chat.IsChat(API.Converter.ToChatId(message.PeerId)))
                {
                    API.Chat.New(API.Converter.ToChatId(message.PeerId));
                }

                bool access = false;
                var user = new API.User(message.From);
                foreach (var donate in Donate)
                {
                    if (donate == user.Donate)
                    {
                        access = true;
                        break;
                    }
                }

                if (access)
                {
                    if (arguments.Length < 3)
                    {
                        result = Data.Commands.Chat.NotCommand;
                    }
                    else
                    {
                        string command = arguments[2];

                        switch (command)
                        {
                            case "тблок":
                                result = TitleBlock(message, arguments);
                                break;
                            case "танблок":
                                result = TitleUnBlock(message, arguments);
                                break;
                            case "фблок":
                                break;
                            case "фанблок":
                                break;
                            default:
                                result = Data.Commands.Chat.NoCommand;

                                break;
                        }
                    }
                }
                else
                {
                    result = Data.Commands.Chat.NoAccess;
                }
            }
            else
            {
                result = Data.Commands.Chat.NoChat;
            }
        }

        private string TitleBlock(Message message, string[] arguments)
        {
            string result = "Неизвестная ошибка.";
            var chat = new API.Chat(API.Converter.ToChatId(message.PeerId));
            if(!chat.Blocked)
            {
                chat.AdminSave = message.From;
                chat.Blocked = true;
                result = Data.Commands.Chat.TitleReadyBlock;
            }
            else
            {
                result = Data.Commands.Chat.TitleIsBlocked;
            }
            return result;
        }

        private string TitleUnBlock(Message message, string[] arguments)
        {
            string result = "Неизвестная ошибка.";
            var chat = new API.Chat(API.Converter.ToChatId(message.PeerId));
            if(chat.Blocked)
            {
                if(message.From == chat.AdminChat || message.From == chat.AdminSave)
                {
                    chat.Blocked = false;
                    chat.AdminSave = 1;
                    result = Data.Commands.Chat.TitleReadyUnBlock;
                }else
                {
                    result = Data.Commands.Chat.TitleNotUnBlock;
                }
            }else
            {
                result = Data.Commands.Chat.TitleNoBlocked;
            }
            return result;
        }

        public static void TitleTrigger(Message message)
        {
            //хуйхуйхуй
        }
    }
}
