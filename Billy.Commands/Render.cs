using System;
using Billy.Models;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Billy.Helpers;
using System.Threading;


namespace Billy.Commands
{
    public class Render
    {
        public static List<ICommand> Commands = null;

        public static void Initialization()
        {
            List<ICommand> commands = new List<ICommand>()
            {
                new Test(),
                new Profile(),
                new About(),
                new DailyMissions(),
                new MySettings(),
                new Nick(),
                new Ban(),
                new Music(),
                new Donate(),
                new Foxs()
            };
            Render.Commands = commands;
        }

        public static void Run(Message message)
        {
            string[] text = Split(message.ExtraFields.Text);
            int countWords = text.Length;
            string name = text[0].ToLower();
            if(name == "билли"||name == "билли," || name == "бил" || name == "бил," || name == "билл" || name == "билл," || name == "billy" || name == "billy,")
            {
                var user = new API.User(message.From);
                if (!API.User.Is(message.From))
                    API.User.New(message.From);
                if(!user.Ban)
                {
                    var commands = Render.Commands;
                    foreach(var command in commands)
                    {
                        if (command.CanExecute(text[1]))
                        {
                            Thread threadRendderExecute = new Thread(new ParameterizedThreadStart(RunCommandExecute));
                            threadRendderExecute.Name = "RenderExecuteCommand";
                            Console.WriteLine("Выполнение потока RenderExecute");
                            threadRendderExecute.Start(new ModelRunCommandExecute
                            {
                                command = command,
                                arguments = text,
                                message = message
                            });
                        }                    
                    }
                }
            }
        }


        public static void RunCommandExecute(object mod)
        {
            var model = (ModelRunCommandExecute)mod;
            var command = model.command;
            var arguments = model.arguments;
            var message = model.message;
            command.Execute(message, arguments);
        }

        private static string[] Split(string message)
        {
            string[] response = message.Split(' ');
            return response;
        }
    }

    public class ModelRunCommandExecute
    {
        public ICommand command { get; set; }
        public string[] arguments { get; set; }
        public Message message { get; set; }
    }
}
