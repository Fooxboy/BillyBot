using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;

namespace Billy.Commands
{
    public class Lot: ICommand
    {
        Data.Commands.IDataCommand data = new Data.Commands.Lot();
        public string Name => data.Name;
        public string Help => data.Help;
        public string FullHelp => data.FullHelp;
        public List<Enums.Billy.Donate> Donate => Samples.AccessDonate.All;

        public void Execute(Message message, string[] arguments)
        {
            string result = "Неизвестная ошибка.";
            var vk = API.Data.GetVk();
            var vkMessage = vk.Messages.GetById(message.MessageId);
            int count = vkMessage.ForwardedMessages.Count;
            if(count < 2)
            {
                result = Data.Commands.Lot.NoForward;
            }else
            {
                var rand = new Random();
                int index = rand.Next(0, count - 1);
                var forwardMessage = vkMessage.ForwardedMessages[index];
                var userId = forwardMessage.UserId.Value;
                var user = vk.Users.Get(userId);
                var firstName = user.FirstName;
                var lastName = user.LastName;
                result = Data.Commands.Lot.Ready(firstName, lastName);
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
