using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;

namespace Billy.Commands
{
    public class Love: ICommand
    {
        Data.Commands.IDataCommand data = new Data.Commands.Love();
        public string Name => data.Name;
        public string Help => data.Help;
        public string FullHelp => data.FullHelp;
        public List<Enums.Billy.Donate> Donate => Samples.AccessDonate.All;

        public void Execute(Message message, string[] arguments)
        {
            string result = "Неизвестная ошибка.";
            var vk = API.Data.GetVk();
            var forwardsMessage = vk.Messages.GetById(message.MessageId).ForwardedMessages;
            if (forwardsMessage.Count == 2)
            {
                if (forwardsMessage[0].UserId != forwardsMessage[1].UserId)
                {
                    var user1 = vk.Users.Get(forwardsMessage[0].UserId.Value).FirstName;
                    var user2 = vk.Users.Get(forwardsMessage[1].UserId.Value).FirstName;
                    var rand = new Random();
                    var value = rand.Next(0, 88);
                    result = Data.Commands.Love.Ready(user1, user2, value);
                }
                else result = Data.Commands.Love.NoOneUser;
            }
            else result = Data.Commands.Love.No2Forward;

            API.Message.Send(new Models.Params.MessageSendParams
            {
                PeerId = message.PeerId,
                Message = result,
                From = message.From
            });
        }
    }
}
