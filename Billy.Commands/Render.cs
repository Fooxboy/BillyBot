using System;
using Billy.Models;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Billy.Helpers;


namespace Billy.Commands
{
    public class Render
    {
        public static List<ICommand> Commands = null;

        public static void Initialization()
        {
            List<ICommand> commands = new List<ICommand>()
            {
                new Test()
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
                if (!user.Is)
                    API.User.New(message.From);
                if(!user.Ban)
                {
                    var commands = Render.Commands;
                    foreach(var command in commands)
                    {
                        if (command.CanExecute(text[1]))
                            command.Execute(message, text);
                    }
                }
            }
        }

        private static string[] Split(string message)
        {
            string[] response = message.Split(' ');
            return response;
        }
    }
}
