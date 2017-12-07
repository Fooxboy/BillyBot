using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;

namespace Billy.Commands
{
    public class Who: ICommand
    {
        Data.Commands.IDataCommand data = new Data.Commands.Who();
        public string Name => data.Name;
        public string Help => data.Help;
        public string FullHelp => data.FullHelp;
        public List<Enums.Billy.Donate> Donate => Samples.AccessDonate.All;

        public void Execute(Message message, string[] arguments)
        {
            string result = "Неизвестная ошибка.";
            if(message.Type == Enums.LongPoll.TypeMessage.Chat)
            {
                var vk = API.Data.GetVk();
                var chatId = API.Converter.ToChatId(message.PeerId);
                List<long> ids = new List<long> { chatId };
                var members = vk.Messages.GetChatUsers(ids, VkNet.Enums.Filters.UsersFields.Domain, VkNet.Enums.SafetyEnums.NameCase.Nom);
                var count = members.Count;
                var random = new Random();
                int index = random.Next(0, count);
                var user = members[index];
                string name = user.FirstName;
                string fam = user.LastName;
                string domain = user.Domain;
                result = Data.Commands.Who.Ready(name, fam, domain, arguments[2]);
            }else
            {
                result = Data.Commands.Who.NoChat;
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
