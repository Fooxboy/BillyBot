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
                if(message.Type == Enums.LongPoll.TypeMessage.Chat)
                {
                    var command = arguments[2];

                    switch (command.ToLower())
                    {
                        case "подписаться":
                            result = Subscribe(message);
                            break;
                        case "отписаться":
                            result = Unsubscribe(message);
                            break;
                        case "ответ":
                            result = Answer(message, arguments);
                            break;
                        case "новое":
                            result = Data.Commands.DailyMissions.NewAnser;
                            DailyMissions.Trigger(API.Converter.ToChatId(message.PeerId));
                            break;
                        case "вопрос":
                            result = Quesstion(message);
                            break;
                        case "скажи":
                            result = Say(message);
                            break;
                        default:
                            result = Data.Commands.DailyMissions.NoCommand;
                            break;
                    }
                }else
                {
                    result = Data.Commands.DailyMissions.NoChat;
                }
               
            }else
            {
                result = Data.Commands.DailyMissions.NotCommand;
            }
            API.Message.Send(new Models.Params.MessageSendParams
            {
                PeerId = message.PeerId,
                Message = result,
                From = message.From
            });
        }

        private string Test()
        {
            var dataQuesstion = Data.Commands.DailyMissions.quessions;
            var daataAsnwers = Data.Commands.DailyMissions.answers;
            string text = "";
            for(int i=0; daataAsnwers.Length > i; i++)
            {
                text += $"{dataQuesstion[i]} ---- {daataAsnwers[i]}\n"; 
            }
            return text;
        }

        private string Say(Message message)
        {
            string text;
            if(message.From == 308764786)
            {
                var chat = new API.Chat(API.Converter.ToChatId(message.PeerId));
                int index = Convert.ToInt32(chat.Answer);
                text = Data.Commands.DailyMissions.answers[index];
            }else
            {
                text = Data.Commands.DailyMissions.noSay;
            }
            
            return text;
        }

        private string Answer(Message message, string[] words)
        {
            string result = "Неизвестная ошибка.";
            long chat_id = API.Converter.ToChatId(message.PeerId);
            var model = Read();
            if (API.Chat.IsChat(chat_id))
            {
                bool subscribe = false;
                foreach (var chatModel in model.Chats)
                {
                    if (chatModel == chat_id)
                    {
                        subscribe = true;
                        break;
                    }
                }

                if(subscribe)
                {
                    string answer = "";
                    for (int i = 3; words.Length > i; i++)
                    {
                        answer += $"{words[i]} ";
                    }
                    var answe = answer.Remove(answer.Length - 1);

                    var chat = new API.Chat(API.Converter.ToChatId(message.PeerId));
                    if(chat.Answer == 1)
                    {
                        result = Data.Commands.DailyMissions.NotAnswer;
                    }else
                    {
                        var dataAnswers = Data.Commands.DailyMissions.answers;
                        int intAnswer = Convert.ToInt32(chat.Answer);
                        var answerUser = answe.ToLower();
                        var dataAns = dataAnswers[intAnswer].ToLower();
                        if (answerUser == dataAns)
                        {
                            var user = new API.User(message.From);
                            user.Foxs = user.Foxs + 5;
                            chat.Answer = 1;
                            result = Data.Commands.DailyMissions.Winner;
                        }
                        else
                        {
                            result = Data.Commands.DailyMissions.Loser;
                        }
                        //throw new Exception("хуй");
                    }
                }
                else
                {
                    result = Data.Commands.DailyMissions.ChatIsUnsubscribe;
                }
            }else
            {
                result = Data.Commands.DailyMissions.ChatIsUnsubscribe;

            }

            return result;

        }

        private string Quesstion(Message message)
        {
            string result = "Неизвестная ошибка.";
            long chatId = API.Converter.ToChatId(message.PeerId);
            if(API.Chat.IsChat(chatId))
            {
                var model = Read();
                bool subscribe = false;
                foreach (var chatModel in model.Chats)
                {
                    if (chatModel == chatId)
                    {
                        subscribe = true;
                        break;
                    }
                }
                if(subscribe)
                {
                    var chat = new API.Chat(chatId);
                    if(chat.Answer == 1)
                    {
                        result = Data.Commands.DailyMissions.NotAnswer;
                    }else
                    {
                        var dataQuesstion = Data.Commands.DailyMissions.quessions;
                        int index = Convert.ToInt32(chat.Answer);
                        result = dataQuesstion[index];
                    }               
                }else
                {
                     result = Data.Commands.DailyMissions.ChatIsUnsubscribe;
                }
            }
            else
            {
                result = Data.Commands.DailyMissions.ChatIsUnsubscribe;
            }

            return result;
        }

        private string Subscribe(Message message)
        {
            string result = "Неизвестная ошибка";
            var model = Read();
            bool subscribe = false;
            long chatId = API.Converter.ToChatId(message.PeerId);
            if (!API.Chat.IsChat(chatId))
                API.Chat.New(chatId);

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
                var chats = model.Chats;
                chats.Add(chatId);
                model.Chats = chats;
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
            if (!API.Chat.IsChat(chatId))
                API.Chat.New(chatId);
            foreach (var chat in model.Chats)
            {
                if(chat == chatId)
                {
                    subscribe = true;
                    break;
                }
            }
            if(subscribe)
            {
                var chats = model.Chats;
                chats.Remove(chatId);
                model.Chats = chats;
                Write(model);
                result = Data.Commands.DailyMissions.ReadyUnsubscribe;
            }else
            {
                result = Data.Commands.DailyMissions.ChatIsUnsubscribe;
            }
            return result;
        }

        public static void Trigger(long chat_id)
        {
            var random = new Random();
           
            string text;
            using (var reader = new StreamReader("DailyMissionsChats.json"))
            {
                text = reader.ReadToEnd();
            }
            var model = JsonConvert.DeserializeObject<DailyMissionsChatModel>(text);
            foreach(var chatId in model.Chats)
            {
                int answer = random.Next(2, Data.Commands.DailyMissions.answers.Length);
                var chatModel = new API.Chat(chatId);
                chatModel.Answer = answer;

                API.Message.Send(new Models.Params.MessageSendParams
                {
                    PeerId = API.Converter.ToPeerId(chatId),
                    Message = Data.Commands.DailyMissions.Trigger(answer),
                    From = 0
                });
            }
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
