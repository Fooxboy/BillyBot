using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;

namespace Billy.Commands
{
    public class FieldOfDreams: ICommand
    {
        Data.Commands.IDataCommand data = new Data.Commands.FieldOfDreams();
        public string Name => data.Name;
        public string Help => data.Help;
        public string FullHelp => data.FullHelp;
        public List<Enums.Billy.Donate> Donate => Samples.AccessDonate.All;

        public void Execute(Message message, string[] arguments)
        {
            string result = "Неизвестная ошибка.";
            
            if(arguments.Length > 2)
            {
                var command = arguments[2];
                switch(command)
                {
                    case "создать":
                        break;
                    default:
                        //Неизвестная подкоманда
                        break;
                }
            }else //не указана подкоманда
        }

        private string Create(long userId, string[] arguments)
        {
            var result = "Неизвестная ошибка.";

            if(arguments.Length == 3|| arguments.Length == 4 )
            {

            }else //Нет гужных данных.

            return result;
        }
    }
}
