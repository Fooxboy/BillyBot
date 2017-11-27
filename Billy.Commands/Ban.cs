using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;

namespace Billy.Commands
{
    public class Ban :ICommand
    {
        Data.Commands.IDataCommand data = new Data.Commands.Ban();
        public string Name => data.Name;
        public string Help => data.Help;
        public string FullHelp => data.FullHelp;
        public List<Enums.Billy.Donate> Donate => Samples.AccessDonate.Diamond;

        public void Execute(Message message, string[] arguments)
        {
            string result = "неизвестная ошибка.";
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
            if (access)
            {
                string command;
                if (arguments.Length >= 3)
                {
                    command = arguments[2];
                    var vkMessage = API.Data.GetVk().Messages.GetById(message.MessageId);
                    if(vkMessage.ForwardedMessages.Count == 0)
                    {
                        result = Data.Commands.Ban.NoId;
                    }else
                    {
                        long? userBanId = vkMessage.ForwardedMessages[0].UserId;
                        switch (command)
                        {
                            case "+":
                               result = Add(userBanId.Value, arguments, message.From);
                            break;
                            case "-":
                                result = Delete(userBanId.Value);
                                break;
                            case "дать":
                                result = Add(userBanId.Value, arguments, message.From);
                                break;
                            case "убрать":
                                result = Delete(userBanId.Value);
                                break;
                            default:
                                result = Data.Commands.Ban.NotCommand;
                                break;
                        }
                    }
                }
                else
                {
                    result = Data.Commands.Ban.NoCommand;
                }
            }else
            {
                result = Data.Commands.Ban.NoAccess;
            }

            API.Message.Send(new Models.Params.MessageSendParams
            {
                PeerId = message.PeerId,
                Message = result,
                From = message.From
            });

        }

        private string Add(long user_id, string[] arguments, long from)
        {
            string result = "Неизвестная ошибка.";

            if (API.User.Is(user_id))
            {
                var user = new API.User(user_id);
                if (arguments.Length >= 4)
                {
                    var time = Int64.Parse(arguments[3]);
                    string title = "Причина не указана.";
                    if (arguments.Length >= 5)
                    {
                        title = arguments[4];
                    }

                    API.Bans.New(new Models.Params.BanAddParams
                    {
                        Id = user.Id,
                        Time = time,
                        From = from,
                        Title = title
                    });
                    user.Ban = true;

                    result = Data.Commands.Ban.ReadyBan;
                }
                else
                {
                    result = Data.Commands.Ban.NoTime;
                }
            }else
            {
                result = Data.Commands.Ban.NoUser;
            }
            return result;
        }

        private string Delete(long id)
        {
            string result = "Неизвестная ошибка";
            if (API.User.Is(id))
            {
                var user = new API.User(id);
                if (user.Ban)
                {
                    API.Bans.Delete(id);
                    user.Ban = false;
                    result = Data.Commands.Ban.ReadyUnBan;
                }else
                {
                    result = Data.Commands.Ban.NotBans;
                }
            }else
            {
                result = Data.Commands.Ban.NoUser;
            }
            return result;
        }
    }
}
