using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;
using Billy.Data.Commands;


namespace Billy.Commands
{
    public class Profile : ICommand
    {
        IDataCommand data = new Data.Commands.Profile();
        public string Name => data.Name;
        public string Help => data.Help;
        public string FullHelp => data.FullHelp;
        public List<Enums.Billy.Donate> Donate => Samples.AccessDonate.All;

        public void Execute(Message message, string[] arguments)
        {
            string result = "Неизвестная ошибка.";
            bool AccessFullProfile = false;
            var DonateFullAccess = Samples.AccessDonate.Vip;
            var user = new API.User(message.From);
            foreach(var donate in DonateFullAccess)
            {
                if(user.Donate == donate)
                {
                    AccessFullProfile = true;
                    break;
                }
            }

            if(arguments.Length == 3)
            {
                if (AccessFullProfile)
                {
                    try
                    {
                        long user_id = Int64.Parse(arguments[2]);
                        var UserNew = new API.User(user_id);
                        if(!UserNew.Is)
                        {
                            result = Data.Commands.Profile.NoUser;
                        }else
                        {
                            User usr = UserNew;
                            result = Data.Commands.Profile.ProfileGet(usr);
                        }
                    }
                    catch(FormatException)
                    {
                        result = Data.Commands.Profile.NoUserId;
                    }                   
                }else
                {
                    result = Data.Commands.Profile.NoAccess;
                }
            }else
            {
                var vk = API.Data.GetVk();
                var message_VK = vk.Messages.GetById(message.MessageId);
                int countMessage = message_VK.ForwardedMessages.Count;
                if(countMessage == 0)
                {
                    User usr = user;
                    result = Data.Commands.Profile.ProfileGet(usr);
                }else
                {
                    if(AccessFullProfile)
                    {
                        var messageForward = message_VK.ForwardedMessages[0];
                        long? user_id = messageForward.FromId;
                        var userNew = new API.User(user_id);
                        User usr = userNew;
                        result = Data.Commands.Profile.ProfileGet(usr);
                    }else
                    {
                        result = Data.Commands.Profile.NoAccess;
                    }
                }
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
