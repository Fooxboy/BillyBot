using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Billy.Models;
using Newtonsoft.Json;

namespace Billy.Commands
{
    public class MySettings : ICommand
    {
        Data.Commands.IDataCommand data = new Data.Commands.MySettings();
        public string Name => data.Name;
        public string Help => data.Help;
        public string FullHelp => data.FullHelp;
        public List<Enums.Billy.Donate> Donate => Samples.AccessDonate.Premuim;

        public void Execute(Message message, string[] arguments)
        {
            string result = "Неизветная ошибка.";
            var user = new API.User(message.From);
            var userDonate = user.Donate;
            bool access = false;
            foreach(var donate in Donate)
            {
                if(donate == userDonate)
                {
                    access = true;
                    break;
                }
            }
            if (access)
            {
                if(arguments[2].ToLower() == "настройки")
                {
                    int countWords = arguments.Length;
                    if (countWords == 3)
                    {
                        result = Data.Commands.MySettings.Settings;
                    }else
                    {
                        switch (arguments[3].ToLower())
                        {
                            case "создать":
                                result = Create(user);
                                break;
                            case "изменить":
                                result = Edit(user, arguments);
                                break;
                            case "сбросить":
                                result = Reset(user);
                                break;
                            default:
                                break;
                        }
                    }
                }else
                {
                    result = Data.Commands.MySettings.NoSetting;
                }
               
            }else
            {
                result = Data.Commands.MySettings.NoAccess;
            }

            

            API.Message.Send(new Models.Params.MessageSendParams
            {
                PeerId = message.PeerId,
                Message = result,
                From = message.From
            });

        }

        private string Reset(API.User user)
        {
            string result = "Неизветная ошибка.";
            if (user.Settings)
            {
                var model = Read(user.Id);
                model = DefaultSettings(user.Id);
                result = Data.Commands.MySettings.ReadyReset;
            }else
            {
                result = Data.Commands.MySettings.NotCreate;

            }
            return result;
        }

        private string Edit(API.User user, string[] argumetns)
        {
            string result = "Неизветная ошибка.";
            if(user.Settings)
            {
                var model = Read(user.Id);
                if(argumetns.Length >= 5)
                {
                    string idcommand = argumetns[4].ToLower();
                    
                    if(argumetns.Length >= 6)
                    {
                        string pCommand = argumetns[5].ToLower();
                        switch (idcommand)
                        {
                            case "1":
                                if (pCommand == "да")
                                {
                                    model.ViewNick = true;
                                    Write(model);
                                    result = Data.Commands.MySettings.Ready(pCommand);
                                }else if(pCommand == "нет")
                                {
                                    model.ViewNick = false;
                                    Write(model);
                                    result = Data.Commands.MySettings.Ready(pCommand);

                                }
                                else
                                {
                                    result = Data.Commands.MySettings.NotParametr;
                                }
                                    break;
                            case "2":
                                if (pCommand == "да")
                                {
                                    model.ViewCommunity = true;
                                    Write(model);
                                    result = Data.Commands.MySettings.Ready(pCommand);

                                }
                                else if (pCommand == "нет")
                                {
                                    model.ViewCommunity = false;
                                    Write(model);
                                    result = Data.Commands.MySettings.Ready(pCommand);

                                }
                                else
                                {
                                    result = Data.Commands.MySettings.Ready(pCommand);
                                }
                                break;
                            default:
                                result = Data.Commands.MySettings.NotId;
                                break;
                        }
                    }
                    else
                    {
                        result = Data.Commands.MySettings.NoParametr;
                    }              
                }
                else
                {
                    result = Data.Commands.MySettings.NoId;
                }
               
            }else
            {
                result = Data.Commands.MySettings.NotCreate;
            }

            //throw new Exception("че за хуйня");
            return result;     
        }

        private string Create(API.User user)
        {
            string result = "неизвестная ошибка.";
            if(!user.Settings)
            {
                CreateFile(user.Id);
                var model = DefaultSettings(user.Id);
                Write(model);
                user.Settings = true;
                result = Data.Commands.MySettings.ReadyCreate;

            }else
            {
                result = Data.Commands.MySettings.IsCreate;
            }
            return result;
        }

        private UserSettingsModel Read(long id)
        {
            string text;
            using (var reader = new StreamReader($"{id}_settings.json"))
            {
                text = reader.ReadToEnd();
            }
            var model = JsonConvert.DeserializeObject<UserSettingsModel>(text);
            return model;

        }

        private void Write(UserSettingsModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            var id = model.Id;
            using (var writer = new StreamWriter($"{id}_settings.json"))
            {
                writer.Write(json);
            }
        }

        private UserSettingsModel DefaultSettings(long id)
        {
            var model = new UserSettingsModel()
            {
                Id = id,
                ViewCommunity = true,
                ViewNick = true
            };
            return model;
        }

        private void CreateFile(long id)
        {
            File.Create($"{id}_settings.json");
        }
    }
}
