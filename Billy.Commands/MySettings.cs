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
                        //вывод справки
                    }else
                    {
                        switch(arguments[3].ToLower())
                        {
                            case "создать":
                                break;
                            case "изменить":
                                break;
                            case "сбросить":
                                break;
                        }

                        string text = "";
                        for (int i = 3; arguments.Length > i; i++)
                        {
                            text += $"{arguments[i]} ";
                        }
                        var yruruu = text.Remove(text.Length - 1);
                    }
                }else
                {
                    //Доступные команды: настройки.
                }
               
            }else
            {
                result = Data.Commands.MySettings.NoAccess;
            }
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
