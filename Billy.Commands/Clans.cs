using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;

namespace Billy.Commands
{
    public class Clans: ICommand
    {
        Data.Commands.IDataCommand data = new Data.Commands.Clans();
        public string Name => data.Name;
        public string Help => data.Help;
        public string FullHelp => data.FullHelp;
        public List<Enums.Billy.Donate> Donate => Samples.AccessDonate.All;

        public void Execute(Message message, string[] arguments)
        {
            string result = "Неизвестная ошибка.";
            var command = arguments[2];
            switch (command.ToLower())
            {
                case "создать":
                    result = Create(message.From, arguments);
                    break;
                case "вступить":
                    result = Join(message.From, arguments);
                    break;
                case "покинуть":
                    result = Leave(message.From);
                    break;
                case "добавить":
                    result = Add(message);
                    break;
                case "инфо":
                    result = Info(message.From);
                    break;
                default:
                    result = Data.Commands.Clans.NotCommand;
                    break;
            }
            API.Message.Send(new Models.Params.MessageSendParams
            {
                PeerId = message.PeerId,
                Message = result,
                From = message.From
            });
        }

        private string Create(long userId, string[] arguments)
        {
            string result = "Неизвестная ошибка.";

            var user = new API.User(userId);
            if (user.Clan == 0)
            {
                if (arguments.Length > 3)
                {
                    string name = arguments[3];
                    var clanId = API.Clan.New(name, userId);
                    user.Clan = clanId;

                    result = Data.Commands.Clans.ReadyCreate;
                }
                else result = Data.Commands.Clans.NotNameClan;
            }
            else result = Data.Commands.Clans.InClan;
            return result;
        }

        private string Leave(long userId)
        {
            string result = "Неизвестная ошибка.";
            var user = new API.User(userId);
            int clanId = user.Clan;
            if (clanId != 0)
            {
                var clan = new API.Clan(clanId);
                var members = clan.Members.Split(' ');
                var membersList = new List<string>();
                foreach (var member in members) membersList.Add(member);
                membersList.Remove(userId.ToString());
                var newMembers = membersList.ToArray();
                string membersStr = "";
                foreach (var member in newMembers) membersStr += $"{member} ";
                clan.Members = membersStr;
                user.Clan = 0;
                result = Data.Commands.Clans.ReadyLeave;

            }
            else result = Data.Commands.Clans.NoClan;

            return result;
        }

        private string Add(Message message)
        {
            string result = "Неизвестная ошибка.";

            var userMain = new API.User(message.From);
            if (userMain.Clan != 0)
            {
                var vk = API.Data.GetVk();
                var vkMessage = vk.Messages.GetById(message.MessageId);
                if (vkMessage.ForwardedMessages.Count != 0)
                {
                    var userId = vkMessage.ForwardedMessages[0].UserId;
                    if (API.User.Is(userId.Value))
                    {
                        var user = new API.User(userId.Value);

                        if (user.Clan == 0)
                        {
                            var clan = new API.Clan(userMain.Clan);
                            var members = clan.Members;
                            members += $"{user.Id} ";
                            clan.Members = members;
                            user.Clan = clan.Id;
                            result = Data.Commands.Clans.ReadyAdd;
                        }
                        else result = Data.Commands.Clans.UserInClan;
                    }
                    else result = Data.Commands.Clans.NotUser;
                }
                else result = Data.Commands.Clans.NoForwardMessage;
            }
            else result = Data.Commands.Clans.NoClan;

            return result;
        }

        private string Join(long userId, string[] arguments)
        {
            string result = "Неизвестная ошибка.";
            var user = new API.User(userId);
            
            if (user.Clan == 0)
            {
                if (arguments.Length > 3)
                {
                    var clanId = Convert.ToInt32(arguments[3]);
                    if (API.Clan.Is(clanId))
                    {
                        var clan = new API.Clan(clanId);

                        var members = clan.Members;
                        members += $"{userId} ";
                        user.Clan = clanId;
                        result = Data.Commands.Clans.ReadyJoin;
                    }
                    else result = Data.Commands.Clans.NotIdClan;
                    
                }
                else result = Data.Commands.Clans.NoIdClan;
            }
            else result = Data.Commands.Clans.InClan;
            return result;
        }

        private string Info(long userId)
        {
            string result = "Неизвестная ошибка.";

            var user = new API.User(userId);

            if (user.Clan != 0)
            {
                var clan = new API.Clan(user.Clan);

                var vk = API.Data.GetVk();

                var members = vk.Users.Get(clan.Members.Split(' '));
                string membersStr = "";
                foreach (var member in members) membersStr += $"\n{member.FirstName} {member.LastSeen}";
                result = Data.Commands.Clans.Info(clan, members[0].FirstName, membersStr);
            }
            else result = Data.Commands.Clans.NoClan;

            return result;
        }
    }
}
