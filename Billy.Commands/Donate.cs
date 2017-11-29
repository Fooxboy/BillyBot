using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;

namespace Billy.Commands
{
    public class Donate :ICommand
    {
        Data.Commands.IDataCommand data = new Data.Commands.Donate();
        public string Name => data.Name;
        public string Help => data.Help;
        public string FullHelp => data.FullHelp;
        List<Enums.Billy.Donate> ICommand.Donate => Samples.AccessDonate.All;

        public void Execute(Message message, string[] arguments)
        {
            string result = "Неизвестная ошибка.";

            if (arguments.Length < 3)
            {
                result = Data.Commands.Donate.NoCommand;
            } else
            {
                string command = arguments[2];

                switch(command.ToLower())
                {
                    case "купить":
                        result = Buy(message, arguments);
                        break;
                    case "список":
                        result = Data.Commands.Donate.ListDonat;
                        break;
                }
            }

            API.Message.Send(new Models.Params.MessageSendParams
            {
                PeerId = message.PeerId,
                Message = result,
                From = message.From
            });
        }

        public string Buy(Message message, string[] arguments)
        {
            string result = "Неизвестная ошибка";
            bool check = false;
            int sum = 0;
            int sumFoxs = 0;
            bool resultBuy = false;
            if(arguments.Length == 3)
            {
                result = Data.Commands.Donate.Buy;
            }else
            {
                string idStr = arguments[3];
                try
                {
                    int id = Int32.Parse(idStr);
                    var user = new API.User(message.From);
                    int Price = 0;
                    Enums.Billy.Donate donate = Enums.Billy.Donate.User;
                    switch (id)
                    {
                        case 2:
                            Price = 69;
                            donate = Enums.Billy.Donate.Vip;
                            break;
                        case 3:
                            Price = 100;
                            donate = Enums.Billy.Donate.Premium;
                            break;
                        case 4:
                            Price = 250;
                            donate = Enums.Billy.Donate.Diamond;
                            break;
                        default:
                            Price = 0;
                            break;
                    }

                    if(Price == 0)
                    {
                        result = Data.Commands.Donate.NoId;
                    }else
                    {
                        check = true;

                        if(user.Foxs >= Price)
                        {
                            user.Donate = donate;
                            user.Foxs -= Price;
                            result = Data.Commands.Donate.Ready;
                            resultBuy = true;
                            sum = Price;
                            sumFoxs = Price;
                        }else
                        {
                            sum = Price;
                            resultBuy = false;
                            result = Data.Commands.Donate.NoMoney;
                        }
                    }
                }catch(FormatException)
                {
                    result = Data.Commands.Donate.NotId;
                }             
            }

            string response = result;

            if(check)
            {
                response = Data.Commands.Donate.Check(message.From, resultBuy, sum, sumFoxs, result);
            }

            return response;
        }
    }
}
