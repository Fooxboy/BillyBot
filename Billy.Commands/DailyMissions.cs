using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;
using Billy.Data.Commands;
using System.IO;
using Newtonsoft.Json;

namespace Billy.Commands
{
    public class DailyMissions: ICommand
    {
        IDataCommand data = new Data.Commands.DailyMissions();
        public string Name => data.Name;
        public string Help => data.Help;
        public string FullHelp => data.FullHelp;
        public List<Enums.Billy.Donate> Donate => Samples.AccessDonate.All;

        public void Execute(Message message, string[] arguments)
        {
            string result = "Неизвестная ошибка.";
            if(!(arguments.Length == 2))
            {
                var command = arguments[2];
                
                switch(command.ToLower())
                {
                    case "подписаться":
                        result = Subscribe(message);
                        break;
                    case "отписаться":
                        result = Unsubscribe(message);
                        break;
                    case "ответ":
                        break;
                    case "новое":
                        break;
                    default:
                        result = Data.Commands.DailyMissions.NoCommand;
                        break;
                }

            }else
            {
                result = Data.Commands.DailyMissions.NotCommand;
            }
        }

        private string Subscribe(Message message)
        {
            string result = "Неизвестная ошибка";
            var model = Read();
            bool subscribe = false;
            long chatId = API.Converter.ToChatId(message.PeerId);
            foreach (var chat in model.Chats)
            {
                if (chat == chatId)
                {
                    subscribe = true;
                    break;
                }
            }
            if(!subscribe)
            {
                model.Chats.Add(chatId);
                Write(model);
                result = Data.Commands.DailyMissions.ReadySubscribe;
            }else
            {
                result = Data.Commands.DailyMissions.ChatIsSubscribe;
            }
            return result;
        }

        private string Unsubscribe(Message message)
        {
            string result = "Неизвестная ошибка.";
            var model = Read();
            bool subscribe = false;
            long chatId = API.Converter.ToChatId(message.PeerId);
            foreach(var chat in model.Chats)
            {
                if(chat == chatId)
                {
                    subscribe = true;
                    break;
                }
            }
            if(subscribe)
            {
                model.Chats.Remove(chatId);
                Write(model);
                result = Data.Commands.DailyMissions.ReadyUnsubscribe;
            }else
            {
                result = Data.Commands.DailyMissions.ChatIsUnsubscribe;
            }
            return result;
        }

        private DailyMissionsChatModel Read()
        {
            string text;
            using(var reader = new StreamReader("DailyMissionsChats.json"))
            {
                text = reader.ReadToEnd();
            }
            var model = JsonConvert.DeserializeObject<DailyMissionsChatModel>(text);
            return model;
            
        }

        private void Write(DailyMissionsChatModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            using(var writer = new StreamWriter("DailyMissionsChats.json"))
            {
                writer.Write(json);
            }
        }
    }
}
