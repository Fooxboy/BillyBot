using System;
using System.Collections.Generic;
using System.Text;
using Billy.Models;

namespace Billy.Commands
{
    public class Foxs : ICommand
    {
        Data.Commands.IDataCommand data = new Data.Commands.Foxs();
        public string Name => data.Name;
        public string Help => data.Help;
        public string FullHelp => data.FullHelp;
        public List<Enums.Billy.Donate> Donate => Samples.AccessDonate.All;

        public void Execute(Message message, string[] arguments)
        {
            string result = "Неизвестнаяя ошибка";

            if(arguments.Length <3)
            {
                result = Data.Commands.Foxs.NoCommand;
            }else
            {
                string command = arguments[2];

                switch(command)
                {
                    case "купить":
                        result = Buy(message, arguments);
                        break;
                    case "вывести":
                        result = ExitPay(message, arguments);
                        break;
                    case "баланс":
                        result = Balance(message.From);
                        break;
                    case "проверить":
                        result = CheckPay(message.From);
                        break;
                    default:
                        result = Data.Commands.Foxs.NotCommand;
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

        private string ExitPay(Message message, string[] arguments)
        {
            string result = "Неизвестная ошибка.";
            if(arguments.Length < 4)
            {
                result = Data.Commands.Foxs.NoWallet;
            }else
            {
                string wallet = arguments[3];
                var user =  new API.User(message.From);
                int count = user.Foxs / 2;
                user.Foxs = 0;
                var res = API.Qiwi.Payments(count, wallet);
                result = Data.Commands.Foxs.ReadyExitPay(count, message.From);
            }
            return result;
        }

        private string CheckPay(long id)
        {
            //проверка...
            string result = "Неизвестная ошибка.";
            var payments = API.Qiwi.PaymentHistory(10);
            bool isDonate = false;
            Qiwi.Payment.Pay thisPay = null;
            var user = new API.User(id);

            foreach(var pay in payments.data)
            {
                if (pay.comment == $"{id}_{user.DonateCount}")
                {
                    int foxs = System.Convert.ToInt32(thisPay.sum.amount);
                    user.Foxs += foxs;
                    result = Data.Commands.Foxs.ReadyPay(id, foxs, user.Foxs);
                    user.DonateCount += 1;
                }
                else
                {
                    result = Data.Commands.Foxs.NoPay;
                }
            }
            return result;
        }

        private string Balance(long id)
        {
            string result = "Неизвестная ошибка.";
            var user = new API.User(id);
            var foxs = user.Foxs;
            result = Data.Commands.Foxs.Balance(foxs);
            return result;
        }

        private string Buy(Message message, string[] arguments)
        {
            var user = new API.User(message.From);
            int count = user.DonateCount;
            string result = "Неизвестная ошибка.";
            var url1 = API.Qiwi.GetUrl(message.From, count);
            var url = API.Data.GetVk().Utils.GetShortLink(new Uri(url1), false);
            result = Data.Commands.Foxs.Buy(url.ShortUrl.AbsoluteUri, message.From,count);
            return result;
        }
    }
}
