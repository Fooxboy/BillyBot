using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;

namespace Billy.Commands
{
    public class Nick : ICommand
    {
        Data.Commands.IDataCommand data = new Data.Commands.Nick();

        public string Name => data.Name;
        public string Help => data.Help;
        public string FullHelp => data.FullHelp;
        public List<Enums.Billy.Donate> Donate => Samples.AccessDonate.All;

        public void Execute(Message message, string[] arguments)
        {
            string result = "неизвестная ошибка.";
            var user = new API.User(message.From);
            var vk = API.Data.GetVk();
            var VkMessage = vk.Messages.GetById(message.MessageId);
            if(arguments.Length >=3)
            {
                if (VkMessage.ForwardedMessages.Count == 0)
                {
                    user.Name = arguments[2];
                    result = Data.Commands.Nick.Ready;
                }
                else
                {
                    bool access = false;

                    foreach (var donate in Samples.AccessDonate.Vip)
                    {
                        if (donate == user.Donate)
                        {
                            access = true;
                            break;
                        }
                    }

                    if (access)
                    {
                        
                        int donateUserFrom = (int)user.Donate;
                        var idUser = VkMessage.ForwardedMessages[0].UserId;
                        if (API.User.Is(idUser))
                        {
                            var NewUser = new API.User(idUser);
                            int donateUserTo = (int)NewUser.Donate;
                            if (donateUserFrom < donateUserTo)
                            {
                                result = Data.Commands.Nick.NoAccessDonate;
                            }
                            else
                            {
                                NewUser.Name = arguments[2];
                                result = Data.Commands.Nick.Ready;
                            }
                        }else
                        {
                            result = Data.Commands.Nick.NoUser;
                        }
                    }
                    else
                    {
                        result = Data.Commands.Nick.NoAccess;
                    }
                }
            }else
            {
                result = Data.Commands.Nick.NotNick;
            }

            API.Message.Send(new Models.Params.MessageSendParams
            {
                PeerId = message.PeerId,
                Message = result,
                From = message.From
            });
        }
    }
}
