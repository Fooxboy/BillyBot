using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;

namespace Billy.Commands
{
    public class Music: ICommand
    {
        Data.Commands.IDataCommand data = new Data.Commands.Music();
        public string Name => data.Name;
        public string Help => data.Help;
        public string FullHelp => data.FullHelp;
        public List<Enums.Billy.Donate> Donate => Samples.AccessDonate.Premuim;

        public void Execute(Message message, string[] arguments)
        {
            string result = "Неизвестная ошибка.";
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
                var vk = API.Data.GetVk();
                var vkMessage = vk.Messages.GetById(message.MessageId);
                if (vkMessage.Attachments.Count == 0)
                {
                    result = Data.Commands.Music.NoAttach;
                } else
                {
                    string strUrls = " ";
                    var vkAttach = vkMessage.Attachments;

                    foreach(var attach in vkAttach)
                    {
                        int i = 1;
                        if (attach.Type == typeof(VkNet.Model.Attachments.Audio))
                        {                      
                            var audio = (VkNet.Model.Attachments.Audio)attach.Instance;
                            var url = API.Audio.Methods.Get($"{audio.OwnerId}_{audio.Id}").Url;
                           // var urlShort = vk.Utils.GetShortLink(url,false);
                            strUrls += $"\n {i} - {url}";       
                        }
                        i++;
                    }

                    result = $"{Data.Commands.Music.Ready} \n {strUrls}";
                }
            }else
            {
                result = Data.Commands.Music.NoAccess;
            }

            string text = Data.Commands.About.GetAbout();
            API.Message.Send(new Models.Params.MessageSendParams
            {
                PeerId = message.PeerId,
                Message = result,
                From = message.From
            });
        }
    }
}
