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
                                result = TitleBlock(message);
                                break;
                            case "танблок":
                                result = TitleUnBlock(message);
                                break;
                            case "фблок":
                                result = PhotoBlock(message);
                                break;
                            case "фанблок":
                                result = PhotoUnBlock(message);
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

        private string TitleBlock(Message message)
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

        private string TitleUnBlock(Message message)
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
            if(API.Chat.IsChat(API.Converter.ToChatId(message.PeerId)))
            {
                var chat = new API.Chat(API.Converter.ToChatId(message.PeerId));

                if(chat.Blocked)
                {
                    if (message.From == chat.AdminChat || message.From == chat.AdminSave)
                    {
                        chat.Name = message.ExtraFields.Attach.sourse_mid;
                    }
                    else
                    {
                        var vk = API.Data.GetVk();
                        vk.Messages.EditChat(API.Converter.ToChatId(message.PeerId), chat.Name);
                    }
                }

                
            }
           
        }

        private string PhotoBlock(Message message)
        {
            string result = "Неизвестная ошибка.";
            var chat = new API.Chat(API.Converter.ToChatId(message.PeerId));
            if(!chat.BlockedPhoto)
            {
                var vk = API.Data.GetVk();
                var vkMess = vk.Messages.GetById(message.MessageId);
                if (vkMess.Attachments.Count != 0)
                {
                    var vkAttach = vkMess.Attachments[0];
                    if (vkAttach.Type == typeof(VkNet.Model.Attachments.Photo))
                    {
                        var photo = (VkNet.Model.Attachments.Photo)vkAttach.Instance;
                        var url = photo.BigPhotoSrc;
                        System.Net.WebClient client = new System.Net.WebClient();
                        string name = $"PhotoBlock_{API.Converter.ToChatId(message.PeerId)}.jpg";
                        client.DownloadFile(url, name);
                        chat.AdminSavePhoto = message.From;
                        chat.BlockedPhoto = true;
                        chat.Photo = name;
                        //vk.Messages.SetChatPhoto();

                        result = Data.Commands.Chat.PhotoReadyBlock;
                    } else
                    {
                        result = Data.Commands.Chat.PhotoNoAttach;
                    }
                } else
                {
                    result = Data.Commands.Chat.PhotoNotAttach;
                }
            }
            else
            {
                result = Data.Commands.Chat.PhotoIsBlocked;
            }
            return result;
        }

        private string PhotoUnBlock(Message message)
        {
            string result = "Неизвестная ошибка.";
            var chat = new API.Chat(API.Converter.ToChatId(message.PeerId));
            if(chat.BlockedPhoto)
            {
                if (message.From == chat.AdminChat || message.From == chat.AdminSavePhoto)
                {
                    System.IO.File.Delete(chat.Photo);
                    chat.AdminSavePhoto = 1;
                    chat.BlockedPhoto = false;
                    chat.Photo = "1";
                    result = Data.Commands.Chat.PhotoReadyUnBlock;
                }else
                {
                    result = Data.Commands.Chat.PhotoNotUnBlock;
                }
            }
            else
            {
                result = Data.Commands.Chat.PhotoNotBlocked;
            }
            return result;
        }
        
        public static void PhotoTrigger(Message message)
        {
            var chat_id = API.Converter.ToChatId(message.PeerId);
            if(API.Chat.IsChat(chat_id))
            {
                var chat = new API.Chat(chat_id);
                if(chat.BlockedPhoto)
                {
                    if (message.From == chat.AdminChat || message.From == chat.AdminSavePhoto)
                    {
                        string photo = message.ExtraFields.Attach.sourse_mid;
                        System.IO.File.Delete(chat.Photo);
                        System.Net.WebClient client = new System.Net.WebClient();
                        string name = $"PhotoBlock_{API.Converter.ToChatId(message.PeerId)}.jpg";
                        client.DownloadFile(photo, name);
                        chat.Photo = name;
                    }
                    else
                    {
                        //загрузка чьленов...
                    }

                }
            }
        }
    }
}
