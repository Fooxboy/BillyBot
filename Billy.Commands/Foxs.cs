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
                        break;
                    case "баланс":
                        result = Balance(message.From);
                        break;
                    case "проверить":
                        break;
                    default:
                        //Неизвестная подкоманда
                        break;

                }
            }
        }

        private string CheckPay(long id)
        {
            //проверка...
            string result = "Неизвестная ошибка.";
            var payments = API.Qiwi.PaymentHistory(10);
            var pays = payments.data;
            bool isDonate = false;

            string json;
            using(var reader = new System.IO.StreamReader("DonateUsers.json"))
            {
                json = reader.ReadToEnd();
            }

            var model = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.DonateUsersModels>(json);

            foreach(var pay in pays)
            {
                if(pay.comment == id.ToString())
                {
                    foreach(var user in model.users)
                    {
                        if(user.Id == id)
                        {
                            foreach(var idPay in user.IDsPay)
                            {
                                if(idPay == pay.txnId)
                                {
                                    isDonate = false;
                                    break;
                                }else
                                {
                                    user.IDsPay.Add(pay.txnId);
                                    
                                    isDonate = true;
                                }
                            }
                        }else
                        {

                            isDonate = true;
                        }
                    }
                    break;
                }
            }

            if(isDonate)
            {

            }else
            {
                //Не найден Ваш донат.
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
            string result = "Неизвестная ошибка.";
            var url1 = API.Qiwi.GetUrl(message.From);
            var url = API.Data.GetVk().Utils.GetShortLink(new Uri(url1), false);
            result = Data.Commands.Foxs.Buy(url.ShortUrl.AbsoluteUri, message.From);
            return result;
        }
    }
}
